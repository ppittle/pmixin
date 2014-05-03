﻿//----------------------------------------------------------------------- 
// <copyright file="VisualStudioOutputWindowAppender.cs" company="Copacetic Software"> 
// Copyright (c) Copacetic Software.  
// <author>Philip Pittle</author> 
// <date>Wednesday, April 30, 2014 5:48:10 PM</date> 
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

using CopaceticSoftware.CodeGenerator.StarterKit.Infrastructure;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;

namespace CopaceticSoftware.CodeGenerator.StarterKit.Logging
{
    public class VisualStudioOutputWindowAppender : AppenderSkeleton
    {
        public IVisualStudioWriter OutputWindow { get; set; }

        public VisualStudioOutputWindowAppender(IVisualStudioWriter outputWindow)
        {
            OutputWindow = outputWindow;

            Layout = new PatternLayout("%-5level %logger - %message%newline");
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            if (null == OutputWindow)
                return;

            if (null == loggingEvent)
                return;

            OutputWindow.OutputString(RenderLoggingEvent(loggingEvent));
        }
    }
}
