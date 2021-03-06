// MvxDefaultColorBindingSet.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using MvvmCross.Plugins.Color.Droid.Binding;

namespace MvvmCross.Plugins.Color.Droid.BindingTargets
{
    [Preserve(AllMembers = true)]
    public class MvxDefaultColorBindingSet
    {
        public void RegisterBindings()
        {
            IMvxTargetBindingFactoryRegistry registry;
            if (!Mvx.TryResolve(out registry))
            {
                MvxTrace.Warning(
                               "No binding registry available - so color bindings will not be used");
                return;
            }

            registry.RegisterFactory(new MvxCustomBindingFactory<View>(
                MvxAndroidColorPropertyBinding.View_BackgroundColor,
                view => new MvxViewBackgroundColorBinding(view)));

            registry.RegisterFactory(new MvxCustomBindingFactory<TextView>(
                MvxAndroidColorPropertyBinding.TextView_TextColor,
                textView => new MvxTextViewTextColorBinding(textView)));
        }
    }
}
