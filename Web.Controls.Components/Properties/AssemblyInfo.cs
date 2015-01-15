using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Web.UI;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Web.Controls.Components")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("Web.Controls.Components")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2013")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("674810e6-b3be-4667-8e0e-bff691531676")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: WebResource("Web.Controls.Components.script.geral.js", "text/javascript")]
[assembly: WebResource("Web.Controls.Components.script.geral-after.js", "text/javascript")]
[assembly: WebResource("Web.Controls.Components.script.jquery-1.9.1.js", "text/javascript")]
[assembly: WebResource("Web.Controls.Components.script.jquery-ui.js", "text/javascript")]
[assembly: WebResource("Web.Controls.Components.script.jQuery.bubbletip-1.0.6.js", "text/javascript")]
[assembly: WebResource("Web.Controls.Components.script.flexigrid.js", "text/javascript")]
[assembly: WebResource("Web.Controls.Components.script.jquery.price-format.js", "text/javascript")]

//[assembly: WebResource("Web.Controls.Components.script.jquery.js", "text/javascript")]
[assembly: WebResource("Web.Controls.Components.css.geral.css", "text/css", PerformSubstitution=true )]
[assembly: WebResource("Web.Controls.Components.css.geral-ie.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("Web.Controls.Components.css.bubbletip.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("Web.Controls.Components.css.bubbletip-IE.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("Web.Controls.Components.css.flexigrid.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("Web.Controls.Components.css.jquery-ui.css", "text/css", PerformSubstitution = true)]


[assembly: WebResource("Web.Controls.Components.images.erro.gif", "image/gif")]
[assembly: WebResource("Web.Controls.Components.images.btnAnteriorAtivo.gif", "image/gif")]
[assembly: WebResource("Web.Controls.Components.images.btnAnteriorAtivo.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.btnAnteriorInativo.gif", "image/gif")]
[assembly: WebResource("Web.Controls.Components.images.btnAnteriorInativo.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.btnAtualizar.gif", "image/gif")]
[assembly: WebResource("Web.Controls.Components.images.btnPrimeiroAtivo.gif", "image/gif")]
[assembly: WebResource("Web.Controls.Components.images.btnPrimeiroAtivo.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.btnPrimeiroInativo.gif", "image/gif")]
[assembly: WebResource("Web.Controls.Components.images.btnPrimeiroInativo.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.btnProximoAtivo.gif", "image/gif")]
[assembly: WebResource("Web.Controls.Components.images.btnProximoAtivo.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.btnProximoInativo.gif", "image/gif")]
[assembly: WebResource("Web.Controls.Components.images.btnUltimoAtivo.gif", "image/gif")]
[assembly: WebResource("Web.Controls.Components.images.btnUltimoAtivo.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.btnUltimoInativo.gif", "image/gif")]

[assembly: WebResource("Web.Controls.Components.images.bubbletip-B-tail.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.bubbletip-B.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.bubbletip-BL-corner.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.bubbletip-BL-corner.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.bubbletip-BR-corner.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.bubbletip-L-R.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.bubbletip-L-tail.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.bubbletip-L.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.bubbletip-R-tail.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.bubbletip-R.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.bubbletip-T-B.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.bubbletip-T-tail.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.bubbletip-T.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.bubbletip-TL-corner.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.bubbletip-TR-corner.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.bubbletip.png", "image/png")]

[assembly: WebResource("Web.Controls.Components.images.wbg.gif", "image/gif")]
[assembly: WebResource("Web.Controls.Components.images.line.gif", "image/gif")]
[assembly: WebResource("Web.Controls.Components.images.hl.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.fhbg.gif", "image/gif")]
[assembly: WebResource("Web.Controls.Components.images.calendar.gif", "image/gif")]
[assembly: WebResource("Web.Controls.Components.images.ddn.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.wbg.gif", "image/gif")]
[assembly: WebResource("Web.Controls.Components.images.uup.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.dn.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.bg.gif", "image/gif")]
[assembly: WebResource("Web.Controls.Components.images.up.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.prev.gif", "image/gif")]
[assembly: WebResource("Web.Controls.Components.images.next.gif", "image/gif")]
[assembly: WebResource("Web.Controls.Components.images.magnifier.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.first.gif", "image/gif")]
[assembly: WebResource("Web.Controls.Components.images.last.gif", "image/gif")]
[assembly: WebResource("Web.Controls.Components.images.load.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.load.gif", "image/gif")]

[assembly: WebResource("Web.Controls.Components.images.animated-overlay.gif", "image/gif")]
[assembly: WebResource("Web.Controls.Components.images.btn-sprite.gif", "image/gif")]
[assembly: WebResource("Web.Controls.Components.images.ui-bg_flat_0_aaaaaa_40x100.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.ui-bg_flat_75_ffffff_40x100.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.ui-bg_glass_55_fbf9ee_1x400.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.ui-bg_glass_65_ffffff_1x400.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.ui-bg_glass_75_dadada_1x400.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.ui-bg_glass_75_e6e6e6_1x400.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.ui-bg_glass_95_fef1ec_1x400.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.ui-bg_highlight-soft_75_cccccc_1x100.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.ui-icons_222222_256x240.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.ui-icons_2e83ff_256x240.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.ui-icons_454545_256x240.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.images.ui-icons_888888_256x240.png", "image/png")]
[assembly: WebResource("Web.Controls.Components.ui-icons_cd0a0a_256x240.png", "image/png")]














