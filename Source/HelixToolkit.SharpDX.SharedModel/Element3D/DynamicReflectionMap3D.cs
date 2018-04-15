﻿/*
The MIT License (MIT)
Copyright (c) 2018 Helix Toolkit contributors
*/

#if NETFX_CORE
using Windows.UI.Xaml;
namespace HelixToolkit.UWP
#else
using System.Windows;
namespace HelixToolkit.Wpf.SharpDX
#endif
{
    using Model.Scene;
    using Core;

    public class DynamicReflectionMap3D : GroupModel3D
    {
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public int Size
        {
            get { return (int)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        /// <summary>
        /// The size property
        /// </summary>
        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.Register("Size", typeof(int), typeof(DynamicReflectionMap3D), new PropertyMetadata(256, (d, e) =>
            {
                ((d as Element3D).SceneNode as IDynamicReflector).FaceSize = (int)e.NewValue;
            }));


        /// <summary>
        /// Gets or sets the far field.
        /// </summary>
        /// <value>
        /// The far field.
        /// </value>
        public double FarField
        {
            get { return (double)GetValue(FarFieldProperty); }
            set { SetValue(FarFieldProperty, value); }
        }

        /// <summary>
        /// The far field property
        /// </summary>
        public static readonly DependencyProperty FarFieldProperty =
            DependencyProperty.Register("FarField", typeof(double), typeof(DynamicReflectionMap3D), new PropertyMetadata(100.0, (d, e) =>
            {
                ((d as Element3D).SceneNode as IDynamicReflector).FarField = (float)(double)e.NewValue;
            }));


        /// <summary>
        /// Gets or sets the near field.
        /// </summary>
        /// <value>
        /// The near field.
        /// </value>
        public double NearField
        {
            get { return (double)GetValue(NearFieldProperty); }
            set { SetValue(NearFieldProperty, value); }
        }

        /// <summary>
        /// The near field property
        /// </summary>
        public static readonly DependencyProperty NearFieldProperty =
            DependencyProperty.Register("NearField", typeof(double), typeof(DynamicReflectionMap3D), new PropertyMetadata(0.1, (d, e) =>
            {
                ((d as Element3D).SceneNode as IDynamicReflector).NearField = (float)(double)e.NewValue;
            }));


        /// <summary>
        /// Gets or sets a value indicating whether this instance is left handed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is left handed; otherwise, <c>false</c>.
        /// </value>
        public bool IsLeftHanded
        {
            get { return (bool)GetValue(IsLeftHandedProperty); }
            set { SetValue(IsLeftHandedProperty, value); }
        }

        /// <summary>
        /// The is left handed property
        /// </summary>
        public static readonly DependencyProperty IsLeftHandedProperty =
            DependencyProperty.Register("IsLeftHanded", typeof(bool), typeof(DynamicReflectionMap3D), new PropertyMetadata(false, (d, e) =>
            {
                ((d as Element3D).SceneNode as IDynamicReflector).IsLeftHanded = (bool)e.NewValue;
            }));



        protected override SceneNode OnCreateSceneNode()
        {
            return new DynamicReflectionNode();
        }
    }
}