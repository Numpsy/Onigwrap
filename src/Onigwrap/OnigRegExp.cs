using System;
using System.Collections.Generic;

namespace Onigwrap
{
    public class OnigRegExp
    {
        private string _lastSearchString;
        private int _lastSearchPosition;
        private OnigResult _lastSearchResult;
        private ORegex _regex;

        public OnigRegExp(string source)
        {
            _lastSearchString = null;
            _lastSearchPosition = -1;
            _lastSearchResult = null;

            _regex = new ORegex(source, false, false);
        }

        public OnigResult Search(string str, in int position)
        {
            if (_lastSearchString == str && _lastSearchPosition <= position &&
                (_lastSearchResult == null || _lastSearchResult.LocationAt(0) >= position))
            {
                return _lastSearchResult;
            }

            _lastSearchString = str;
            _lastSearchPosition = position;
            _lastSearchResult = GetOnigResult(str, position);
            return _lastSearchResult;
        }

        private OnigResult GetOnigResult(string data, in int position)
        {
            return _regex.SafeSearch(data, position);
        }
    }
}
