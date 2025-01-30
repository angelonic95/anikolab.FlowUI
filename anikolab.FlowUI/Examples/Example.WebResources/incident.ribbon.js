if (typeof (Example) === "undefined") { var Example = {}; }
if (typeof (Example.Incident) === "undefined") { Example.Incident = { __namespace: true }; }
if (typeof (Example.Incident.Ribbon) === "undefined") { Example.Incident.Ribbon = { __namespace: true }; }


Example.Incident.Ribbon.Form = new function () {
	var _self = this;
	let _availableActions = null;

	_self.getAvailableActions = async function (formContext) {

		if (!_availableActions) {
			_availableActions = FlowUI.Common.getAvailableActions(formContext, "ribbon");
		}
		return _availableActions;

	};

	_self.Button1Command = {
		canExecute: async function (formContext) {

			const flags = await _self.getAvailableActions(formContext);
			return (flags?.showButton1 ?? false) && formContext.getAttribute("prioritycode").getValue() === 2 //Normal;
		},
		execute: async function (formContext) {
			Xrm.Navigation.openAlertDialog("Click Button 1");
		}
	};

	_self.GetInfoCommand = {
		canExecute: async function (formContext) {

			const flags = await _self.getAvailableActions(formContext);
			return flags?.showGetInfoFlyOut ?? false
		},
		execute: async function (formContext) {
			Xrm.Navigation.openAlertDialog("Click Button 3");
		}
	};

	_self.GetIdInfoCommand = {
		canExecute: async function (formContext) {

			const flags = await _self.getAvailableActions(formContext);
			return flags?.showGetId ?? false
		},
		execute: async function (formContext) {
			let recordId = formContext.data.entity.getId();
			Xrm.Navigation.openAlertDialog("ID : " + recordId);
		}
	};

	_self.GetEntityInfoCommand = {
		canExecute: async function (formContext) {

			const flags = await _self.getAvailableActions(formContext);
			return flags?.showGetEntityName ?? false
		},
		execute: async function (formContext) {
			let entityName = formContext.data.entity.getEntityName();
			Xrm.Navigation.openAlertDialog("Entity Name: " + entityName);
		}
	};

	_self.GetNameCommand = {
		canExecute: async function (formContext) {

			const flags = await _self.getAvailableActions(formContext);
			return flags?.showGetName ?? false
		},
		execute: async function (formContext) {
			let title = formContext.getAttribute("title").getValue();
			Xrm.Navigation.openAlertDialog("Title: " + title);
		}
	}
};

