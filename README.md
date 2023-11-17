# Enterprise
Using CRUD design Pattern (c) 2023 to make enterprise LOB apps
- Separating the UI from the business logic by introducing 'CRUD' Db layer
- UI logic is simplified
- Tuples utilised for set and get of UI properties make mappping of ui to db fields intuitive
- Business Logic is moved to CRUD layer
- Introducing unit tests will make your WinForms app more robust.
- Adoption of Azure services becomes much easier with a sound architecture, and essential code can also be easily shared with the Mobile App’s spin-off.


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

----

# Background notes:
## Is MvvM Maintainable / Readable code?
Not quite.. its hard to debug, changes when used in the context 
Works like this... With Mvvm we control the UI via a Controller or ViewModel, you get the required Service over the ServiceProvider, which the Controller/ViewModels got via Dependency Injection.
Dependency Injection means, _depending_ on what UI-Stack (or even inside a Unit Test) we're actually running, the ui will do different things:
Depending on in what context the ViewModel is executed, it effectively needs to do different things.
To overcome this, we inject the ViewModel on instantiation with a service provider, which provides an abstract way to interact with the respective UI elements.
..confused?

### Maui
XAML based UI stack, it is **common practice to write the XAML code to design the UI**, and add the binding directly in that process. Uses command binding (which is also called Commanding).

### WPF 
Pre MAUI UI stack , vector based and databinding

### Winform DotNet 4.8 
WIth DotNet 4.8 there isnt a “bindable” way to connect business logic methods in the data source.

### Winform Core8 / .Net8 
.net8 WinForms Command Binding features : UI-Controller/MVVM approach
WinForms RAD designer provides a UI for linking up the commands of a data source with the form interactively,
The Command Binding in WinForms .net 8 RAD will make it easier to modernize WinForms applications in a feasible way. 
Separating the UI from the business logic by introducing UI Controller
Using ViewModels in additional UI stacks like .NET MAUI allows you to take parts of a LOB app cross-platform and have Mobile Apps for areas where it makes sense. 
#### Using Command Binding in .net8 Windows Forms apps
The is the Ultimate dream .. UI - Controllers | ViewModels that have no dependencies on UI front end loaded code so unit tests for such apps can be implemented much more easily
Up to now, there wasn’t a “bindable” way to connect business logic methods in the data source – or more accurately: the UI-Controller or ViewModel – with the UI
UI-Controller/MVVM approach in WinForms with the new WinForms Command Binding features.
Adapting a UI-Controller architecture for new or existing WinForms apps
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

### INotifyPropertyChanged & PropertyChanged
Idea is to remote-control the actual UI through data binding


