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
