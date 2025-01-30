if (typeof (FlowUI) === "undefined") { var FlowUI = {}; }
if (typeof (FlowUI.Common) === "undefined") { FlowUI.Common = { __namespace: true }; }
if (typeof (FlowUI.Common.Flatten) === "undefined") { FlowUI.Common.Flatten = { __namespace: true }; }
if (typeof (FlowUI.Common.Utilities) === "undefined") { FlowUI.Common.Utilities = { __namespace: true }; }

const API_NAME = "new_getavailableactions";


FlowUI.Common = new function () {
	var _self = this;
	_self.getAvailableActions = async function (formContext, actionType) {

		return FlowUI.Common.Utilities.AvailableAction.execute(formContext, actionType)
	};
};

FlowUI.Common.Flatten = new function () {
	var _self = this;

	_self.getAvailableActions = async function (formContext, actionType, formTypeMapper, currentFormType) {

		return FlowUI.Common.Utilities.AvailableAction.executeFlatten(formContext, actionType, formTypeMapper, currentFormType);
	};
};

FlowUI.Common.Utilities = new function () {
	var _self = this;
	_self.Action = {
		execute: async function (recordId, actionType, entityName) {
			let request = {

				recordId: recordId,
				actionType: actionType,
				entityName: entityName
			};
			let requestMetadata = {
				boundParameter: null,
				operationType: 0,
				operationName: API_NAME,
				parameterTypes: {
					recordId: { typeName: "Edm.String", structuralProperty: 1 },
					actionType: { typeName: "Edm.String", structuralProperty: 1 },
					entityName: { typeName: "Edm.String", structuralProperty: 1 }
				},
			};

			request.getMetadata = function () {
				return requestMetadata;
			};

			let executeResultsRaw = await Xrm.WebApi.online.execute(request);

			if (executeResultsRaw.ok === false) {
				return;
			}

			var executeResults = await executeResultsRaw.json();
			return executeResults;
		}
	};

	_self.FlattenJson = {
		flatten: function (mapper, formType, json) {
			const flatJson = {};
			for (let key in json) {
				const value = json[key];
				if (!Object.values(mapper).includes(key)) {
					if (typeof value === "object" && value !== null) {
						for (let nestedKey in value) {
							flatJson[nestedKey] = value[nestedKey];
						}
					} else {
						flatJson[key] = value;
					}
				}
				if (key === mapper[formType]) {
					if (typeof value === "object" && value !== null) {
						for (let nestedKey in value) {
							flatJson[nestedKey] = value[nestedKey];
						}
					} else {
						flatJson[key] = value;
					}
				}
			}

			return flatJson;
		}

	};

	_self.AvailableAction = {
		execute: async function (formContext, actionType) {

			return _self.Action.execute(formContext.data.entity.getId(), actionType, formContext.data.entity.getEntityName())
				.then(response => {
					return JSON.parse(response.Response).ribbon;
				})
				.catch(error => {
					return null;
				});
		},

		executeFlatten: async function (formContext, actionType, formTypeMapper, currentFormType) {

			return _self.Action.execute(formContext.data.entity.getId(), actionType, formContext.data.entity.getEntityName())
				.then(response => {
					let json = JSON.parse(response.Response).ribbon;
					var flattenJson = _self.FlattenJson.flatten(formTypeMapper, currentFormType, json);
					return flattenJson;
				})
				.catch(error => {
					return null;
				});
		}
	};
};