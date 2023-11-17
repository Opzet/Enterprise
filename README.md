# Enterprise
Using CRUD design Pattern (c) 2023 to make enterprise LOB apps

## WinForms Command Binding features : UI-Controller/MVVM approach
UI-Controllers/ViewModels are not supposed to have dependencies to certain UI technologies, unit tests for such apps can be implemented much more easily

## Using Command Binding in Windows Forms apps
Up to now, there wasn’t a “bindable” way to connect business logic methods in the data source – or more accurately: the UI-Controller or ViewModel – with the UI
UI-Controller/MVVM approach in WinForms with the new WinForms Command Binding features.
Adapting a UI-Controller architecture for new or existing WinForms apps
###INotifyPropertyChanged & PropertyChanged
Idea is to remote-control the actual UI through data binding
```csharp

public class NotifyPropertyChangeDemo : INotifyPropertyChanged
    {
        // The event that is fired when a property changes.
        public event PropertyChangedEventHandler? PropertyChanged;

        // Backing field for the property.
        private string? _lastName;
        private string? _firstName;

        // The property that is being monitored.
        public string? LastName
        {
            get => _lastName;

            set
            {
                if (_lastName == value)
                {
                    return;
                }

                _lastName = value;

                // Notify the UI that the property has changed.
                // Using CallerMemberName at the call site will automatically fill in
                // the name of the property that changed.
                OnPropertyChanged();
            }
        }

        public string? FirstName
        {
            get => _firstName;

            set
            {
                if (_firstName == value)
                {
                    return;
                }

                _firstName = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "") 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

```

## Pattern
![CRUD LOB Pattern](https://github.com/Opzet/Enterprise/blob/main/CRUD%20Pattern/CRUD%20LOB%20Pattern.png?raw=true)

## Tech Stack

### Winform DotNet 4.8 

### Entity Framework EF Visual Designer 

You can read more about how to use the designer in the [Documentation site](https://msawczyn.github.io/EFDesigner/).
<table><tbody><tr><td>
<img src="https://msawczyn.github.io/EFDesigner/images/Designer.jpg">
</td></tr></tbody></table>

This Visual Studio 2022 extension is the easiest way to add a consistently correct Entity Framework (EF6 or EFCore) model to your project.
Robust implementation of https://learn.microsoft.com/en-us/visualstudio/data-tools/entity-data-model-tools-in-visual-studio

#### SqlServer/LocalDb


### WebAPi
 DbContext code is written to allow consumption via webapi
### Enterprise Message Hub 
#### Realtime Multiuser app messaging
DbContext CRUD creates pub/sub message bus (signalr) events


