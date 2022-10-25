// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Reflection;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Advices
{
    internal interface IIntroduceMemberAdviceProperties
    {
        Visibility Visibility { get;  }

        bool? IsVirtual { get;  }

        MemberOverrideAction OverrideAction { get;  }
    }

}
