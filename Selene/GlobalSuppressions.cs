// -----------------------------------------------------------------------
// <copyright file="GlobalSuppressions.cs" company="Laura Kolcavova">
// Copyright (c) Laura Kolcavova. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

// This file is used by Code Analysis to maintain SuppressMessage.
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.
using System.Diagnostics.CodeAnalysis;

#pragma warning disable SA1404 // Code analysis suppression should have justification
[assembly: SuppressMessage("StyleCop.CSharp.NamingRules", "SA1311:Static readonly fields should begin with upper-case letter", Justification = "<Pending>", Scope = "member", Target = "~F:Selene.SessionDataStorage.sessions")]
#pragma warning restore SA1404 // Code analysis suppression should have justification
