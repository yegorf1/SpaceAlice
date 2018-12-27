using System;

namespace SpaceAlice.Core.Exceptions {
    public class SpaceAliceException : Exception {
        protected SpaceAliceException(string s) : base(s) {}
        protected SpaceAliceException() {}
    }
}