#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("zlK29DZeum6WWV0Ont/8JHT2oHEPrKoncVFV4wwUuhy3wKxmHIaDiCdnI8AhXuHQ99h8ypFf/5Koxmy1b9VqYxpGZzkHAkh0Z+CRTZJDwbf8gBnQvRprioTu5aBY2vJrsPYCu4ctPOSJy+QmBD1YBYW521QqZtWcjICssNfuDobksGShp1ocBGBXNovsscddUmpPI68fy/3i5JjG+wWuF0JBl7TV+u9s+1AKwx0W0LXw2ZYyIJIRMiAdFhk6lliW5x0REREVEBP77Pd8oi+NeouwXk0XWUn8lcPaTfeC/STqGfNBOu03yuR0k8qUvINTT+XMc2p8fmsdWeqTlzoC2wlNdfuSER8QIJIRGhKSEREQrAIBCVZ3zGP6GHYNa9SjQRITERAR");
        private static int[] order = new int[] { 11,12,10,6,4,13,13,7,9,11,13,11,13,13,14 };
        private static int key = 16;

        public static byte[] Data() {
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
