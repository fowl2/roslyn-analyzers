﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using Analyzer.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow.GlobalFlowStateAnalysis;

namespace Microsoft.CodeQuality.Analyzers.QualityGuidelines.AvoidMultipleEnumerations
{
    public partial class AvoidMultipleEnumerations
    {
        private enum InvocationTimes
        {
            OneTime,
            TwoOrMore
        }

        private class InvocationCountAnalysisValue : CacheBasedEquatable<InvocationCountAnalysisValue>, IAbstractAnalysisValue
        {
            public ISymbol EnumeratedSymbol { get; }

            public InvocationTimes InvocationTimes { get; }


            public InvocationCountAnalysisValue(ISymbol enumeratedSymbol, InvocationTimes invocationTimes)
            {
                EnumeratedSymbol = enumeratedSymbol;
                InvocationTimes = invocationTimes;
            }

            public bool Equals(IAbstractAnalysisValue other)
            {
                if (other is InvocationCountAnalysisValue otherValue)
                {
                    return EnumeratedSymbol.Equals(otherValue.EnumeratedSymbol) && InvocationTimes == otherValue.InvocationTimes;
                }

                return false;
            }

            public IAbstractAnalysisValue GetNegatedValue()
            {
                return this;
            }

            protected override void ComputeHashCodeParts(ref RoslynHashCode hashCode)
            {
                hashCode.Add(EnumeratedSymbol.GetHashCode());
                hashCode.Add(InvocationTimes.GetHashCode());
            }

            protected override bool ComputeEqualsByHashCodeParts(CacheBasedEquatable<InvocationCountAnalysisValue> obj)
            {
                var other = (InvocationCountAnalysisValue)obj;
                return other.EnumeratedSymbol.GetHashCode() == EnumeratedSymbol.GetHashCode()
                   && other.InvocationTimes.GetHashCode() == InvocationTimes.GetHashCode();
            }
        }
    }
}