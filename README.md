# Enterprise

These Enterprise project examples leverage a Layered Seperation Design Pattern for **programming** (i.e Coding againsta a pattern) rather than Front End **Coded** Spaghetti.

**Key Benefits:**
- **Tuple Intellisense** Design Time intellisense Tuple matching for datafields to Ui properties
- **Intuitive UI Logic**: The use of tuples for property assignments simplifies the synchronization between UI components and database fields.
- **Separation of Concerns**: Introducing a 'CRUD' database layer to uncouple UI elements from core business processes.
- **Centralized Business Logic**: Migrating logic to the CRUD layer fosters a more maintainable and organized code structure.
- **Enhanced Testing**: Incorporating unit testing to ensure application stability and integrity.
- **Cloud Compatibility**: Architectural soundness eases the transition to Azure, facilitating mobile application development and codebase sharing.

### Seperation Layers [EFDb <-> Poco <-> Tuples <-> Ui ]

View is decoupled from Business Login and Database

#### Flow : Ui <-> Db 

View = User Interface

```
UI View 
    <- View_xxx.cs ->
            View via Tuples to POCO
                <- CRUD_xxx.cs ->
                        POCO to EF Db Table
-------------
View to Db Flow
-------------
    UI View
        Product item = View.Product(int Quantity, string Product);
            [View via Tuples to POCO]
                CRUD.Product_CreateUpdate (Product item); // Update if Id Assigned
                    [POCO to Db]
                        Db Table
```

#### Flow ->  Db to Ui
```
EF Db Table
    <- CRUD_xxxx.cs -> 
            EF Table to POCO
                 <- View_xxxx.cs ->
                    POCO to Tuples to View

-------------
Db to View Flow
-------------
     Product Db Table
        CRUD_Product.cs : CRUD.DbtoProduct(long ProductId)
        <-- [EFDb to POCO] << Db via EF : CRUD Layer >> -->
            VIew_Product.cs : (int Quantity, string Product) View.ProducttoUI (Product item)
            <-- [POCOO-> View via Tuples] << UI via Tuples : View Layer>> -->
                UI View Updated
```



    
Create/Update 

## Tech Stack  





### Db Database - CRUD Data Functions
Entityframework 6.4
RAD -> EF Visual Editor 


## CRUD Pattern Overview

At the heart of the project is the CRUD LOB pattern, crafted to bolster the maintainability and scalability of enterprise software. 

This strategy is approach aimed at using Winform RAD with Entityframework ORM RAD for  Line of Business applications into the future with solid foundations and clear, scalable structure.

Avoiding boilerplate MvvM, Databinding, dependancy injection and allowing for step through debugging.

![Pattern](https://github.com/Opzet/Enterprise/blob/main/CRUD%20Pattern/CRUD%20LOB%20Pattern.png?raw=true)

## Technology Stack
Note: Graphical Rapid Application Development (RAD) used where possible
A pattern for a Frontend and Backend solution to avoid frontend loaded code when using RAD tools. 


### Front End : Winform DotNet 4.8

RAD Tool -> Winform Dot Net 4.8 

### Back End : Entity Framework 

RAD Tool -> EF Visual Designer for db schema [Documentation site](https://msawczyn.github.io/EFDesigner/).

![EF Visual Designer](https://msawczyn.github.io/EFDesigner/images/Designer.jpg)

### SqlServer/LocalDb

### WebAPI

The DbContext code is tailored for consumption via WebAPI, providing a flexible and scalable approach to data access.



#### Realtime Multiuser App Messaging
SignalR Enterprise Message Hub, Publish / Subscribe with INotify 

The DbContext CRUD operations generate publish/subscribe message bus events via SignalR, enabling real-time communication across the application.

---

# Background Development Notes:

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
