// -----------------------------------------------------------------------
// <copyright file="MDString.cs" company="Ubiquity.NET Contributors">
// Copyright (c) Ubiquity.NET Contributors. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using LLVMSharp.Interop;

namespace Ubiquity.NET.Llvm
{
    /// <summary>Stores a string in Metadata</summary>
    public class MDString
        : LlvmMetadata
    {
        /// <summary>Gets the string from the metadata node</summary>
        /// <returns>String this node wraps</returns>
        public override string ToString()
        {
            // Q#: we currently expect exactly one context, since we have no way
            // to map an LLVM Metadata to its context (this was done in Ubiquity via a custom
            // native method).
            var context = ContextCache.Single();
            var asValue = context.ContextHandle.MetadataAsValue(this.MetadataHandle);
            return asValue.GetMDString();
        }

        internal MDString(LLVMMetadataRef handle)
            : base(handle)
        {
        }
    }
}
