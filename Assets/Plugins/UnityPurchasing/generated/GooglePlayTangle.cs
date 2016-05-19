#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("HoppGOnDS3pixoX7pOjfwMVi25Qv0kt6HPtVSnSJ2iq95gT8Tao7ImXm6OfXZebt5WXm5udhuGbLm+WDwz/IYTMDNxwrrrNH6vKhHBtugmVVyVjHCsJYRVAy0eaLH4CAAPxSEWHxtx7vNRmlUFdH6YNncf3YR9k80CBctBPDBGcajmpfnFfmW+ldiY2R5x0VBViqYAUXkyzWvHgiu8YKgJjdYxE/g2q649HloiVIXjJwO7R+pU3+8Ccqv744gPszl1s/yZs2lLVlLSG85JeMrJl2VV6/KAMSZFDB66tRIaLoDHuH3McPsCK0uIKxAjQMf6FZFV0LWmkOeyeuEu/T29kn8ZvXZebF1+rh7s1hr2EQ6ubm5uLn5Hhd4US8n1NqpuXk5ufm");
        private static int[] order = new int[] { 11,13,13,9,8,13,8,9,9,10,12,13,12,13,14 };
        private static int key = 231;

        public static byte[] Data() {
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
