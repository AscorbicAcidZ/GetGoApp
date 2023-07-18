using Android.Content;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using GetGoApp.Class;
using GetGoApp.Droid.Entry_Render;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessRender))] // Place the assembly attribute here
namespace GetGoApp.Droid.Entry_Render
{

    public class BorderlessRender: EntryRenderer
    {
        public BorderlessRender(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // Remove the underline
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }

}