# Enterprise
The CRUD design pattern shifts this paradigm towards a more testable and reusable service with features like `INotifyPropertyChanged` & `PropertyChanged` for multiuser concurrency and UI remote-control through data binding.

Project aims to modernize and streamline the development of enterprise Line of Business (LOB) applications using C# Winform by utilizing the CRUD design pattern, to overcome poor practice of front end loaded / code behind issue when coding rather than programming agaisnt a pattern that allows for testing and scaling applications.

**Key Benefits:**
- **Separation of Concerns**: The 'CRUD' database layer decouples the UI from the business logic.
- **Simplified UI Logic**: Utilizes tuples for setting and getting UI properties, facilitating intuitive mapping between UI and database fields.
- **Business Logic Centralization**: By moving to the CRUD layer, we achieve a cleaner and more maintainable codebase.
- **Unit Testing**: Integration of unit tests enhances the robustness of your WinForms application.
- **Cloud Readiness**: A well-architected solution simplifies the adoption of Azure services and allows for code sharing with mobile counterparts.

## Pattern Overview

The CRUD LOB pattern is designed to enhance the maintainability and scalability of enterprise applications.

![CRUD LOB Pattern](https://github.com/Opzet/Enterprise/blob/main/CRUD%20Pattern/CRUD%20LOB%20Pattern.png?raw=true)

## Technology Stack

### Winform DotNet 4.8

A complete Frontend and Backend solution that traditionally leads to tightly coupled and frontend-loaded code. 



### Entity Framework EF Visual Designer

A Visual Studio 2022 extension that provides a user-friendly interface for adding Entity Framework (EF6 or EFCore) models to your project. It ensures a robust implementation of Entity Framework as per Microsoft's official guidelines.

You can dive deeper into the designer's features on the [Documentation site](https://msawczyn.github.io/EFDesigner/).

![EF Visual Designer](https://msawczyn.github.io/EFDesigner/images/Designer.jpg)

### SqlServer/LocalDb

### WebAPI

The DbContext code is tailored for consumption via WebAPI, providing a flexible and scalable approach to data access.

### Enterprise Message Hub 

#### Realtime Multiuser App Messaging

The DbContext CRUD operations generate publish/subscribe message bus events via SignalR, enabling real-time communication across the application.

---

# Background Notes:

## Is MVVM Maintainable / Readable?

The MVVM pattern can be challenging to debug and adapt due to its complexity and dependency on the UI context. It's often perceived that backend developers prefer not to engage with UI/UX, while frontend designers may lack coding expertise.

### Maui

In MAUI, a common practice is to write the XAML code for UI design and incorporate data binding directly.

### UI Markup Languages (React/Js/HTML5)

These technologies necessitate a separation between the frontend and backend, employing markup languages like XHTML/XAML and design tools like Figma, Sketch, and Lunacy. Tools for converting designs to code are also available, such as Fantastech.

### WPF

WPF is an integrated solution for layout, databinding, and cross-platform support, now evolving into WinUI3/MAUI.

### Winform DotNet 4.8

With DotNet 4.8, there is a lack of "bindable" options to connect business logic methods in the data source.

### Winform Core8 / .Net8

The .Net8 WinForms introduces Command Binding features, facilitating a UI-Controller/MVVM approach and enabling more straightforward modernization of WinForms applications.

#### Using Command Binding in .net8 Windows Forms Apps

This new feature streamlines the process of connecting UI elements with business logic, promoting a clear separation between UI and backend code.

```csharp
public class NotifyPropertyChangeDemo : INotifyPropertyChanged
{
    // Event fired when a property changes.
    public event PropertyChangedEventHandler? PropertyChanged;

    // Backing fields.
    private string? _lastName;
    private string? _firstName;

    // Properties with change notification.
    public string? LastName
    {
        get => _lastName;
        set => SetProperty(ref _lastName, value);
    }

    public string? FirstName
    {
        get => _firstName;
        set => SetProperty(ref _firstName, value);
    }

    // Method to set the property and notify UI.
    protected virtual void SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(backingField, value)) return;
        backingField = value;
        OnPropertyChanged(propertyName);
    }

    // Method to notify the change of a property.
    protected virtual void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
