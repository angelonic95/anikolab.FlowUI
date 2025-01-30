if (typeof (Example) === "undefined") { var Example = {}; }
if (typeof (Example.Account) === "undefined") { Example.Account = { __namespace: true }; }
if (typeof (Example.Account.Ribbon) === "undefined") { Example.Account.Ribbon = { __namespace: true }; }

Example.Account.Ribbon.Form = new function () {
	var _self = this;
	let _availableActions = {};

	const formTypeMapper = {
		1: "create",
		2: "edit",
		3: "create"
	};

	_self.getAvailableActions = async function (formContext) {
		let currentFormType = formContext.ui.getFormType();
		if (!_availableActions || (_availableActions[formTypeMapper[currentFormType]] === undefined || _availableActions[formTypeMapper[currentFormType]] === null)) {
			_availableActions[formTypeMapper[currentFormType]]  = FlowUI.Common.Flatten.getAvailableActions(formContext, "ribbon", formTypeMapper, currentFormType);
		}
		return _availableActions[formTypeMapper[currentFormType]];
	};

	_self.Button1Command = {
		canExecute: async function (formContext) {

			const flags = await _self.getAvailableActions(formContext);
			return (flags?.showButton1 ?? false)
		},
		execute: async function (formContext) {
			Xrm.Navigation.openAlertDialog("Click Button 1");
		}
	};

	_self.Button2Command = {
		canExecute: async function (formContext) {

			const flags = await _self.getAvailableActions(formContext);
			return (flags?.showButton2 ?? false)
		},
		execute: async function (formContext) {
			Xrm.Navigation.openAlertDialog("Click Button 1");
		}
	};

};

