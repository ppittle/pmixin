﻿//----------------------------------------------------------------------- 
// <copyright file="InheritingFromHostPreservesMemberAccess.cs" company="Copacetic Software"> 
// Copyright (c) Copacetic Software.  
// <author>Philip Pittle</author> 
// <date>Friday, October 11, 2013 4:09:17 PM</date> 
// Licensed under the Apache License, Version 2.0,
// you may not use this file except in compliance with this License.
//  
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an 'AS IS' BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright> 
//-----------------------------------------------------------------------

using CopaceticSoftware.pMixins.CodeGenerator.Tests.IntegrationTests.CompileTests.ProtectedMembersTests;
using CopaceticSoftware.pMixins.TheorySandbox.COVERED.HostCanAccessProtectedMembersInMixin;

namespace CopaceticSoftware.pMixins.TheorySandbox.COVERED.InheritingFromHostPreservesMemberAccess
{
    /// <summary>
    /// Covered in:
    ///     <see cref="ChildOfTargetCanAccessProtectedMembers"/>
    /// 
    /// This class inherits from a class that mixin's a class w/ a protected member
    /// <see cref="HostCanAccessProtectedMembersInMixinMixin.prettyName"/>
    /// </summary>
    public class InheritingFromHostPreservesMemberAccessSpec : HostCanAccessProtectedMembersInMixinSpec
    {
    }
}
