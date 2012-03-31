//   Copyright 2011 Microsoft Corporation
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

namespace System.Data.OData
{
    #region Namespaces.
    using System.Collections.Generic;
    #endregion Namespaces.

    /// <summary>
    /// Class representing the a workspace of a data service.
    /// </summary>
#if INTERNAL_DROP
    internal sealed class ODataWorkspace : ODataAnnotatable
#else
    public sealed class ODataWorkspace // : ODataAnnotatable
#endif
    {
        /// <summary>
        /// The set of collections in this workspace.
        /// </summary>
        public IEnumerable<ODataResourceCollectionInfo> Collections
        {
            get;
            set;
        }
    }
}