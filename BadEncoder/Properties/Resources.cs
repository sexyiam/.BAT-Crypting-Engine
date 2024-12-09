using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;


namespace BadEncoder.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (BadEncoder.Properties.Resources.resourceMan == null)
          BadEncoder.Properties.Resources.resourceMan = new ResourceManager("PhantomX.BadEncoder.Properties.Resources", typeof (BadEncoder.Properties.Resources).Assembly);
        return BadEncoder.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => BadEncoder.Properties.Resources.resourceCulture;
      set => BadEncoder.Properties.Resources.resourceCulture = value;
    }

    internal static byte[] Bypass_Net_Loader
    {
      get
      {
        return (byte[]) BadEncoder.Properties.Resources.ResourceManager.GetObject(nameof (Bypass_Net_Loader), BadEncoder.Properties.Resources.resourceCulture);
      }
    }

    internal static byte[] Net_Encoder_Startup
    {
      get
      {
        return (byte[]) BadEncoder.Properties.Resources.ResourceManager.GetObject(nameof (Net_Encoder_Startup), BadEncoder.Properties.Resources.resourceCulture);
      }
    }
  }
}
