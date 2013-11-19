﻿/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. 
 *
 * This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the Apache License, Version 2.0, please send an email to 
 * vspython@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Apache License, Version 2.0.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * ***************************************************************************/

namespace Microsoft.NodejsTools.Npm.SPI
{
    internal class NpmUninstallCommand : NpmCommand{
        public NpmUninstallCommand(
            string fullPathToRootPackageDirectory,
            string packageName,
            DependencyType type,
            bool global = false,
            string pathToNpm = null,
            bool useFallbackIfNpmNotFound = true)
            : base(fullPathToRootPackageDirectory, pathToNpm, useFallbackIfNpmNotFound)
        {
            Arguments = global
                            ? string.Format("uninstall {0} --g", packageName)
                            : string.Format(
                                "uninstall {0} --{1}",
                                packageName,
                                (type == DependencyType.Standard
                                     ? "save"
                                     : (type == DependencyType.Development ? "save-dev" : "save-optional")));
        }
    }
}