using FontAwesome5.Extensions;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace FontAwesome5.NetCore30.Example.ViewModels
{
  public class MainWindowViewModel : INotifyPropertyChanged
  {
    public MainWindowViewModel()
    {
      AllIcons = Enum.GetValues(typeof(EFontAwesomeIcon)).Cast<EFontAwesomeIcon>()
                  .OrderBy(i => i.GetStyle()).ThenBy(i => i.GetLabel()).ToList();
      AllIcons.Remove(EFontAwesomeIcon.None);
      UpdateVisibleIcons();

      FlipOrientations = Enum.GetValues(typeof(EFlipOrientation)).Cast<EFlipOrientation>().ToList();
      SpinDuration = 5;
      PulseDuration = 5;

      FontSize = 30;
      Rotation = 0;

      Visibilities = Enum.GetValues(typeof(Visibility)).Cast<Visibility>().ToList();
      Visibility = Visibility.Visible;
    }

    public Visibility Visibility { get; set; }
    public EFontAwesomeIcon SelectedIcon { get; set; }

    public bool SpinIsEnabled { get; set; }
    public double SpinDuration { get; set; }
    public bool PulseIsEnabled { get; set; }
    public double PulseDuration { get; set; }
    public EFlipOrientation FlipOrientation { get; set; }
    public double FontSize { get; set; }
    public double Rotation { get; set; }

    public List<Visibility> Visibilities { get; set; } = new List<Visibility>();
    public List<EFlipOrientation> FlipOrientations { get; set; } = new List<EFlipOrientation>();
    public List<EFontAwesomeIcon> AllIcons { get; set; } = new List<EFontAwesomeIcon>();

    public event PropertyChangedEventHandler PropertyChanged;

    #region Visible Icon Filtering
    
    public List<EFontAwesomeIcon> VisibleIcons { get; private set; }

    public string FilterText { get; set; }
    private void OnFilterTextChanged()
    {
      UpdateVisibleIcons();
    }

    private void UpdateVisibleIcons()
    {
      var addAll = string.IsNullOrWhiteSpace(FilterText);

      //Confirm regex is valid
      if (!addAll)
      {
        try
        {
          _ = Regex.IsMatch(string.Empty, FilterText);
        }
        catch (Exception)
        {
          addAll = true;
        }
      }

      //Add all if no proper filter is applied
      VisibleIcons = addAll
        ? AllIcons
        : new List<EFontAwesomeIcon>(AllIcons.Where(icon => Regex.IsMatch(
          icon.GetInformation().Label
          , FilterText
          , RegexOptions.IgnoreCase
        )));

      SelectedIcon = VisibleIcons.FirstOrDefault();
    }

    #endregion
  }
}
