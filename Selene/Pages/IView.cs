// -----------------------------------------------------------------------
// <copyright file="IView.cs" company="Laura Kolcavova">
// Copyright (c) Laura Kolcavova. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Selene.Pages
{
    /// <summary>
    /// An interface which represents web view. Used for <see cref="Page"/> and <see cref="PartialView"/> instances.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// A load method used for initialization or assertion that page was loaded successfully.
        /// </summary>
        void Load();
    }
}
