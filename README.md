# anikolab.FlowUI

# Dynamics 365 Ribbon & Subgrid Optimizer

This project includes two libraries:
- C# for the Custom API structure
- JavaScript for integration in Ribbon JS files


The key feature of this solution is that the API is called only once for all buttons, improving performance and reducing redundant calls. It also supports Subgrid optimization and potentially Forms.
It is ideal for managing feature flags, role-based checks, or configuration entities, optimizing button visibility based on centralized logic.

# Available examples in the Examples folder 📂
# Custom API
Includes an API example structured using the FlowUI library, leveraging builders for a more structured API definition.
# Web Resources
- account.ribbon.js

Uses the FlowUI library to retrieve data based on the form type.
The client processes a JSON that defines both form-specific and global actions.
Example JSON:
```json
{
  "ribbon": {
    "create": {
      "showButton2": false,
      "showButton3": false,
      "showButton4": false
    },
    "edit": {
      "showButton2": true,
      "showButton3": false,
      "showButton4": false
    },
    "showButton1": true
  }
}
```
For an edit form, it is converted to:
```json
{"showButton2":true,"showButton3":false,"showButton4":false,"showButton1":true}
```
For a new form, it is converted to:
```json
{"showButton2":false,"showButton3":false,"showButton4":false,"showButton1":true}
```
This approach allows the API to be called when the form type changes (e.g., from "new" to "edit").
- incident.ribbon.js

Uses the FlowUI library in a more direct (flat) way, without making API calls when the form type changes.


# How to use the tool

# Requirements

- A C# project with a Custom API

- A ribbon file where the JavaScript library will be included

# Integration Steps

1. Adding the C# Library

- Integrate the FlowUI library into your C# project.

- Create the necessary builders for your API according to project requirements.

2. Adding the JavaScript Library

- Add the JavaScript library as a dependency in the ribbon file.

- Modify the library to include the name of your Custom API.

- Create a JavaScript method to invoke your API using the FlowUI library.

# Important Notes

It is essential to modify the JavaScript library to specify the correct name of the Custom API before using it.

# Conclusion

By following these steps, you will successfully integrate FlowUI into your Custom API and manage calls via JavaScript in the ribbon file.
