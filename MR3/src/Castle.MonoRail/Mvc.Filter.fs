﻿//  Copyright 2004-2012 Castle Project - http://www.castleproject.org/
//  Hamilton Verissimo de Oliveira and individual contributors as indicated. 
//  See the committers.txt/contributors.txt in the distribution for a 
//  full listing of individual contributors.
// 
//  This is free software; you can redistribute it and/or modify it
//  under the terms of the GNU Lesser General Public License as
//  published by the Free Software Foundation; either version 3 of
//  the License, or (at your option) any later version.
// 
//  You should have received a copy of the GNU Lesser General Public
//  License along with this software; if not, write to the Free
//  Software Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA
//  02110-1301 USA, or see the FSF site: http://www.fsf.org.

namespace Castle.MonoRail

    open System
    open System.Web
    open Castle.MonoRail.Routing
    open Castle.MonoRail.Hosting.Mvc.Typed
    open Castle.MonoRail.Hosting.Mvc

    [<AllowNullLiteral>]
    type FilterExecutionContext(context:ActionExecutionContext) = 
        // Todo: implement a copy constructor on ActionExecutionContext
        inherit ActionExecutionContext (context.ActionDescriptor, context.ControllerDescriptor, context.Prototype, context.HttpContext, context.RouteMatch)

        let result : Ref<ActionResult> = ref null

        do
            base.Exception <- context.Exception

        /// If a filter decides to take over and return a specific action (say redirecting)
        member x.ActionResult with get() = !result and set(v) = result := v


    [<Interface;AllowNullLiteral>]
    type IActionFilter =
        interface 
            abstract member Execute : context:FilterExecutionContext -> unit
        end

    [<Interface;AllowNullLiteral>]
    type IBeforeActionFilter =
        inherit IActionFilter

    [<Interface;AllowNullLiteral>]
    type IAfterActionFilter =
        inherit IActionFilter
        

    [<Interface;AllowNullLiteral>]
    type IExceptionFilter =
        inherit IActionFilter
        
