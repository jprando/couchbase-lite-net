﻿// 
//  QueryParameters.cs
// 
//  Author:
//   Jim Borden  <jim.borden@couchbase.com>
// 
//  Copyright (c) 2017 Couchbase, Inc All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
// 
//  http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
// 

using System;
using System.Collections.Generic;

using Couchbase.Lite.Logging;
using Couchbase.Lite.Util;

using JetBrains.Annotations;

using Newtonsoft.Json;

namespace Couchbase.Lite.Query
{
    /// <summary>
    /// A class which contains parameters for an <see cref="IQuery"/>
    /// </summary>
    public sealed class QueryParameters
    {
        #region Constants

        private const string Tag = nameof(QueryParameters);

        #endregion

        #region Variables

        [NotNull]
        private readonly Dictionary<string, object> _params = new Dictionary<string, object>();

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets a <see cref="Boolean"/> value in the parameters
        /// </summary>
        /// <param name="name">The name of the key to set</param>
        /// <param name="value">The value to set</param>
        /// <returns>The parameters object for further processing</returns>
        [NotNull]
        [ContractAnnotation("name:null => halt")]
        public QueryParameters SetBoolean(string name, bool value)
        {
            SetValue(name, value);
            return this;
        }

        /// <summary>
        /// Sets a <see cref="DateTimeOffset"/> value in the parameters
        /// </summary>
        /// <param name="name">The name of the key to set</param>
        /// <param name="value">The value to set</param>
        /// <returns>The parameters object for further processing</returns>
        [NotNull]
        [ContractAnnotation("name:null => halt")]
        public QueryParameters SetDate(string name, DateTimeOffset value)
        {
            SetValue(name, value);
            return this;
        }

        /// <summary>
        /// Sets a <see cref="Double"/> value in the parameters
        /// </summary>
        /// <param name="name">The name of the key to set</param>
        /// <param name="value">The value to set</param>
        /// <returns>The parameters object for further processing</returns>
        [NotNull]
        [ContractAnnotation("name:null => halt")]
        public QueryParameters SetDouble(string name, double value)
        {
            SetValue(name, value);
            return this;
        }

        /// <summary>
        /// Sets a <see cref="Single"/> value in the parameters
        /// </summary>
        /// <param name="name">The name of the key to set</param>
        /// <param name="value">The value to set</param>
        /// <returns>The parameters object for further processing</returns>
        [NotNull]
        [ContractAnnotation("name:null => halt")]
        public QueryParameters SetFloat(string name, float value)
        {
            SetValue(name, value);
            return this;
        }

        /// <summary>
        /// Sets an <see cref="Int32"/> value in the parameters
        /// </summary>
        /// <param name="name">The name of the key to set</param>
        /// <param name="value">The value to set</param>
        /// <returns>The parameters object for further processing</returns>
        [NotNull]
        [ContractAnnotation("name:null => halt")]
        public QueryParameters SetInt(string name, int value)
        {
            SetValue(name, value);
            return this;
        }

        /// <summary>
        /// Sets an <see cref="Int64"/> value in the parameters
        /// </summary>
        /// <param name="name">The name of the key to set</param>
        /// <param name="value">The value to set</param>
        /// <returns>The parameters object for further processing</returns>
        [NotNull]
        [ContractAnnotation("name:null => halt")]
        public QueryParameters SetLong(string name, long value)
        {
            SetValue(name, value);
            return this;
        }

        /// <summary>
        /// Sets a <see cref="String"/> value in the parameters
        /// </summary>
        /// <param name="name">The name of the key to set</param>
        /// <param name="value">The value to set</param>
        /// <returns>The parameters object for further processing</returns>
        [NotNull]
        [ContractAnnotation("name:null => halt")]
        public QueryParameters SetString(string name, string value)
        {
            SetValue(name, value);
            return this;
        }

        /// <summary>
        /// Sets an untyped value in the parameters
        /// </summary>
        /// <param name="name">The name of the key to set</param>
        /// <param name="value">The value to set</param>
        /// <returns>The parameters object for further processing</returns>
        [NotNull]
        [ContractAnnotation("name:null => halt")]
        public QueryParameters SetValue(string name, object value)
        {
            CBDebug.MustNotBeNull(Log.To.Query, Tag, nameof(name), name);

            _params[name] = value;
            return this;
        }

        #endregion

        #region Overrides

        /// <inheritdoc />
        [NotNull]
        public override string ToString()
        {
            return JsonConvert.SerializeObject(_params) ?? "(null)";
        }

        #endregion
    }
}
