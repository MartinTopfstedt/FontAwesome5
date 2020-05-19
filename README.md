# FontAwesome5

[![Build Status](https://dev.azure.com/codinion/FontAwesome5/_apis/build/status/MartinTopfstedt.FontAwesome5?branchName=master)](https://dev.azure.com/codinion/FontAwesome5/_build/latest?definitionId=11&branchName=master)

WPF (.Net and .Net Core) and UWP controls for the iconic SVG, font, and CSS toolkit Font Awesome 5.

Font Awesome: https://github.com/FortAwesome/Font-Awesome

+ Current Version: v5.13.0

# Getting Started

#### Installation

```Install-Package FontAwesome5```

https://www.nuget.org/packages/FontAwesome5

#### Usage XAML

The usage is the same like the version from charri, just the FontAwesomeIcon enumeration has changed to EFontAwesomeIcon and has the Styles included, which means "Flag" changed to "Solid_Flag" or "Regular_Flag".

https://github.com/charri/Font-Awesome-WPF/blob/master/README-WPF.md#usage-xaml

#### Usage XAML SVG

The SvgAwesome can be used like the ImageAwesome.

``` 
<Window x:Class="FontAwesome5.WPF.Example"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:fa5="http://schemas.fontawesome.com/icons/"
        Title="FontAwesome5.WPF.Example" Height="300" Width="300">
    <Grid  Margin="20">
        <fa5:SvgAwesome Icon="Solid_Flag" VerticalAlignment="Center" HorizontalAlignment="Center" />
    </Grid>
</Window>
```

## Converters (WPF only)

#### ImageSourceConverter

https://github.com/charri/Font-Awesome-WPF/blob/master/README-WPF.md#imagesourceconverter

#### LabelConverter

Gets the Label/Name of a EFontAwesomeIcon. The converter parameter can contain a format string, where {0} is the label/name and {1} is the style.

Example:
```
<Window x:Class="FontAwesome5.WPF.Example"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:fa5="http://schemas.fontawesome.com/icons/"
        Title="FontAwesome5.WPF.Example" Height="300" Width="300">
    <Window.Resources>
        <fa5:LabelConverter x:Key="LabelConverter"/>
    </Window.Resources>
    <Grid  Margin="20">        
        <TextBlock Text="{Binding EFontAwesomeIcon, Converter={StaticResource LabelConverter}}"/>                
        <TextBlock Text="{Binding EFontAwesomeIcon, Converter={StaticResource LabelConverter}, ConverterParameter='{}{0} ({1})'}"/>
    </Grid>
</Window>
```

#### StyleConverter

Gets the EFontAwesomeStyle of a EFontAwesomeIcon.

Example:
```
<Window x:Class="FontAwesome5.WPF.Example"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:fa5="http://schemas.fontawesome.com/icons/"
        Title="FontAwesome5.WPF.Example" Height="300" Width="300">
    <Window.Resources>
        <fa5:StyleConverter x:Key="StyleConverter"/>
    </Window.Resources>
    <Grid  Margin="20">        
        <TextBlock Text="{Binding EFontAwesomeIcon, Converter={StaticResource StyleConverter}}"/>                
    </Grid>
</Window>
```

# Credits

* @davegandy: https://github.com/FortAwesome/Font-Awesome
* @charri: https://github.com/charri/Font-Awesome-WPF
