; ModuleID = 'marshal_methods.x86.ll'
source_filename = "marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [339 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [672 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 67
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 66
	i32 15721112, ; 2: System.Runtime.Intrinsics.dll => 0xefe298 => 107
	i32 32687329, ; 3: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 256
	i32 34715100, ; 4: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 290
	i32 34839235, ; 5: System.IO.FileSystem.DriveInfo => 0x2139ac3 => 47
	i32 39109920, ; 6: Newtonsoft.Json.dll => 0x254c520 => 198
	i32 39485524, ; 7: System.Net.WebSockets.dll => 0x25a8054 => 79
	i32 42639949, ; 8: System.Threading.Thread => 0x28aa24d => 144
	i32 66541672, ; 9: System.Diagnostics.StackTrace => 0x3f75868 => 29
	i32 67008169, ; 10: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 331
	i32 68219467, ; 11: System.Security.Cryptography.Primitives => 0x410f24b => 123
	i32 72070932, ; 12: Microsoft.Maui.Graphics.dll => 0x44bb714 => 196
	i32 82292897, ; 13: System.Runtime.CompilerServices.VisualC.dll => 0x4e7b0a1 => 101
	i32 95598293, ; 14: Supabase.dll => 0x5b2b6d5 => 204
	i32 101534019, ; 15: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 274
	i32 117431740, ; 16: System.Runtime.InteropServices => 0x6ffddbc => 106
	i32 120558881, ; 17: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 274
	i32 122350210, ; 18: System.Threading.Channels.dll => 0x74aea82 => 138
	i32 134690465, ; 19: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 294
	i32 142721839, ; 20: System.Net.WebHeaderCollection => 0x881c32f => 76
	i32 149972175, ; 21: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 123
	i32 159306688, ; 22: System.ComponentModel.Annotations => 0x97ed3c0 => 13
	i32 162612358, ; 23: MimeMapping => 0x9b14486 => 197
	i32 165246403, ; 24: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 230
	i32 176265551, ; 25: System.ServiceProcess => 0xa81994f => 131
	i32 182336117, ; 26: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 276
	i32 184328833, ; 27: System.ValueTuple.dll => 0xafca281 => 150
	i32 195452805, ; 28: vi/Microsoft.Maui.Controls.resources.dll => 0xba65f85 => 328
	i32 199333315, ; 29: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xbe195c3 => 329
	i32 205061960, ; 30: System.ComponentModel => 0xc38ff48 => 18
	i32 209399409, ; 31: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 228
	i32 220171995, ; 32: System.Diagnostics.Debug => 0xd1f8edb => 26
	i32 230216969, ; 33: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 250
	i32 230752869, ; 34: Microsoft.CSharp.dll => 0xdc10265 => 1
	i32 231409092, ; 35: System.Linq.Parallel => 0xdcb05c4 => 58
	i32 231814094, ; 36: System.Globalization => 0xdd133ce => 41
	i32 246610117, ; 37: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 90
	i32 261689757, ; 38: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 233
	i32 276479776, ; 39: System.Threading.Timer.dll => 0x107abf20 => 146
	i32 278686392, ; 40: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 252
	i32 280482487, ; 41: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 249
	i32 280992041, ; 42: cs/Microsoft.Maui.Controls.resources.dll => 0x10bf9929 => 300
	i32 291076382, ; 43: System.IO.Pipes.AccessControl.dll => 0x1159791e => 53
	i32 298918909, ; 44: System.Net.Ping.dll => 0x11d123fd => 68
	i32 317674968, ; 45: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 328
	i32 318968648, ; 46: Xamarin.AndroidX.Activity.dll => 0x13031348 => 219
	i32 321597661, ; 47: System.Numerics => 0x132b30dd => 82
	i32 336156722, ; 48: ja/Microsoft.Maui.Controls.resources.dll => 0x14095832 => 313
	i32 342366114, ; 49: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 251
	i32 347068432, ; 50: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 202
	i32 356389973, ; 51: it/Microsoft.Maui.Controls.resources.dll => 0x153e1455 => 312
	i32 360082299, ; 52: System.ServiceModel.Web => 0x15766b7b => 130
	i32 367780167, ; 53: System.IO.Pipes => 0x15ebe147 => 54
	i32 374914964, ; 54: System.Transactions.Local => 0x1658bf94 => 148
	i32 375677976, ; 55: System.Net.ServicePoint.dll => 0x16646418 => 73
	i32 379916513, ; 56: System.Threading.Thread.dll => 0x16a510e1 => 144
	i32 385762202, ; 57: System.Memory.dll => 0x16fe439a => 61
	i32 392610295, ; 58: System.Threading.ThreadPool.dll => 0x1766c1f7 => 145
	i32 395744057, ; 59: _Microsoft.Android.Resource.Designer => 0x17969339 => 335
	i32 403441872, ; 60: WindowsBase => 0x180c08d0 => 164
	i32 435591531, ; 61: sv/Microsoft.Maui.Controls.resources.dll => 0x19f6996b => 324
	i32 441335492, ; 62: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 234
	i32 442565967, ; 63: System.Collections => 0x1a61054f => 12
	i32 450948140, ; 64: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 247
	i32 451504562, ; 65: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 124
	i32 456227837, ; 66: System.Web.HttpUtility.dll => 0x1b317bfd => 151
	i32 459347974, ; 67: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 112
	i32 465846621, ; 68: mscorlib => 0x1bc4415d => 165
	i32 469710990, ; 69: System.dll => 0x1bff388e => 163
	i32 476646585, ; 70: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 249
	i32 485463106, ; 71: Microsoft.IdentityModel.Abstractions => 0x1cef9442 => 186
	i32 486930444, ; 72: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 262
	i32 498788369, ; 73: System.ObjectModel => 0x1dbae811 => 83
	i32 500358224, ; 74: id/Microsoft.Maui.Controls.resources.dll => 0x1dd2dc50 => 311
	i32 503918385, ; 75: fi/Microsoft.Maui.Controls.resources.dll => 0x1e092f31 => 305
	i32 513247710, ; 76: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 185
	i32 526420162, ; 77: System.Transactions.dll => 0x1f6088c2 => 149
	i32 527452488, ; 78: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 294
	i32 530272170, ; 79: System.Linq.Queryable => 0x1f9b4faa => 59
	i32 539058512, ; 80: Microsoft.Extensions.Logging => 0x20216150 => 181
	i32 540030774, ; 81: System.IO.FileSystem.dll => 0x20303736 => 50
	i32 545304856, ; 82: System.Runtime.Extensions => 0x2080b118 => 102
	i32 546455878, ; 83: System.Runtime.Serialization.Xml => 0x20924146 => 113
	i32 549171840, ; 84: System.Globalization.Calendars => 0x20bbb280 => 39
	i32 557405415, ; 85: Jsr305Binding => 0x213954e7 => 287
	i32 569601784, ; 86: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x21f36ef8 => 285
	i32 577335427, ; 87: System.Security.Cryptography.Cng => 0x22697083 => 119
	i32 592146354, ; 88: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x234b6fb2 => 319
	i32 601371474, ; 89: System.IO.IsolatedStorage.dll => 0x23d83352 => 51
	i32 605376203, ; 90: System.IO.Compression.FileSystem => 0x24154ecb => 43
	i32 610194910, ; 91: System.Reactive.dll => 0x245ed5de => 213
	i32 613668793, ; 92: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 118
	i32 627609679, ; 93: Xamarin.AndroidX.CustomView => 0x2568904f => 239
	i32 627931235, ; 94: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 317
	i32 639843206, ; 95: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 245
	i32 643868501, ; 96: System.Net => 0x2660a755 => 80
	i32 662205335, ; 97: System.Text.Encodings.Web.dll => 0x27787397 => 135
	i32 663517072, ; 98: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 281
	i32 666292255, ; 99: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 226
	i32 672442732, ; 100: System.Collections.Concurrent => 0x2814a96c => 8
	i32 683518922, ; 101: System.Net.Security => 0x28bdabca => 72
	i32 688181140, ; 102: ca/Microsoft.Maui.Controls.resources.dll => 0x2904cf94 => 299
	i32 690569205, ; 103: System.Xml.Linq.dll => 0x29293ff5 => 154
	i32 691348768, ; 104: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 296
	i32 693804605, ; 105: System.Windows => 0x295a9e3d => 153
	i32 699345723, ; 106: System.Reflection.Emit => 0x29af2b3b => 91
	i32 700284507, ; 107: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 291
	i32 700358131, ; 108: System.IO.Compression.ZipFile => 0x29be9df3 => 44
	i32 706645707, ; 109: ko/Microsoft.Maui.Controls.resources.dll => 0x2a1e8ecb => 314
	i32 709557578, ; 110: de/Microsoft.Maui.Controls.resources.dll => 0x2a4afd4a => 302
	i32 720511267, ; 111: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 295
	i32 722857257, ; 112: System.Runtime.Loader.dll => 0x2b15ed29 => 108
	i32 735137430, ; 113: System.Security.SecureString.dll => 0x2bd14e96 => 128
	i32 748832960, ; 114: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 200
	i32 752232764, ; 115: System.Diagnostics.Contracts.dll => 0x2cd6293c => 25
	i32 755313932, ; 116: Xamarin.Android.Glide.Annotations.dll => 0x2d052d0c => 216
	i32 759454413, ; 117: System.Net.Requests => 0x2d445acd => 71
	i32 762598435, ; 118: System.IO.Pipes.dll => 0x2d745423 => 54
	i32 763346851, ; 119: Websocket.Client => 0x2d7fbfa3 => 214
	i32 772621961, ; 120: Supabase.Core.dll => 0x2e0d4689 => 205
	i32 775507847, ; 121: System.IO.Compression => 0x2e394f87 => 45
	i32 777317022, ; 122: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 323
	i32 789151979, ; 123: Microsoft.Extensions.Options => 0x2f0980eb => 184
	i32 790371945, ; 124: Xamarin.AndroidX.CustomView.PoolingContainer.dll => 0x2f1c1e69 => 240
	i32 804715423, ; 125: System.Data.Common => 0x2ff6fb9f => 22
	i32 807930345, ; 126: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x302809e9 => 254
	i32 823281589, ; 127: System.Private.Uri.dll => 0x311247b5 => 85
	i32 830298997, ; 128: System.IO.Compression.Brotli => 0x317d5b75 => 42
	i32 832635846, ; 129: System.Xml.XPath.dll => 0x31a103c6 => 159
	i32 834051424, ; 130: System.Net.Quic => 0x31b69d60 => 70
	i32 843511501, ; 131: Xamarin.AndroidX.Print => 0x3246f6cd => 267
	i32 873119928, ; 132: Microsoft.VisualBasic => 0x340ac0b8 => 3
	i32 877678880, ; 133: System.Globalization.dll => 0x34505120 => 41
	i32 878954865, ; 134: System.Net.Http.Json => 0x3463c971 => 62
	i32 904024072, ; 135: System.ComponentModel.Primitives.dll => 0x35e25008 => 16
	i32 911108515, ; 136: System.IO.MemoryMappedFiles.dll => 0x364e69a3 => 52
	i32 920281169, ; 137: Supabase.Functions => 0x36da6051 => 206
	i32 926902833, ; 138: tr/Microsoft.Maui.Controls.resources.dll => 0x373f6a31 => 326
	i32 928116545, ; 139: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 290
	i32 952186615, ; 140: System.Runtime.InteropServices.JavaScript.dll => 0x38c136f7 => 104
	i32 955402788, ; 141: Newtonsoft.Json => 0x38f24a24 => 198
	i32 956575887, ; 142: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 295
	i32 958433135, ; 143: MusicianAssistantMobile.dll => 0x3920876f => 0
	i32 966729478, ; 144: Xamarin.Google.Crypto.Tink.Android => 0x399f1f06 => 288
	i32 967690846, ; 145: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 251
	i32 975236339, ; 146: System.Diagnostics.Tracing => 0x3a20ecf3 => 33
	i32 975874589, ; 147: System.Xml.XDocument => 0x3a2aaa1d => 157
	i32 986514023, ; 148: System.Private.DataContractSerialization.dll => 0x3acd0267 => 84
	i32 987214855, ; 149: System.Diagnostics.Tools => 0x3ad7b407 => 31
	i32 992768348, ; 150: System.Collections.dll => 0x3b2c715c => 12
	i32 994442037, ; 151: System.IO.FileSystem => 0x3b45fb35 => 50
	i32 1001831731, ; 152: System.IO.UnmanagedMemoryStream.dll => 0x3bb6bd33 => 55
	i32 1012816738, ; 153: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 271
	i32 1019214401, ; 154: System.Drawing => 0x3cbffa41 => 35
	i32 1028951442, ; 155: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 180
	i32 1029334545, ; 156: da/Microsoft.Maui.Controls.resources.dll => 0x3d5a6611 => 301
	i32 1031528504, ; 157: Xamarin.Google.ErrorProne.Annotations.dll => 0x3d7be038 => 289
	i32 1035644815, ; 158: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 224
	i32 1036536393, ; 159: System.Drawing.Primitives.dll => 0x3dc84a49 => 34
	i32 1044663988, ; 160: System.Linq.Expressions.dll => 0x3e444eb4 => 57
	i32 1052210849, ; 161: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 258
	i32 1067306892, ; 162: GoogleGson => 0x3f9dcf8c => 172
	i32 1082857460, ; 163: System.ComponentModel.TypeConverter => 0x408b17f4 => 17
	i32 1084122840, ; 164: Xamarin.Kotlin.StdLib => 0x409e66d8 => 292
	i32 1089187994, ; 165: Websocket.Client.dll => 0x40ebb09a => 214
	i32 1098259244, ; 166: System => 0x41761b2c => 163
	i32 1118262833, ; 167: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 314
	i32 1121599056, ; 168: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll => 0x42da3e50 => 257
	i32 1127624469, ; 169: Microsoft.Extensions.Logging.Debug => 0x43362f15 => 183
	i32 1149092582, ; 170: Xamarin.AndroidX.Window => 0x447dc2e6 => 284
	i32 1157931901, ; 171: Microsoft.EntityFrameworkCore.Abstractions => 0x4504a37d => 174
	i32 1168523401, ; 172: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 320
	i32 1170634674, ; 173: System.Web.dll => 0x45c677b2 => 152
	i32 1175144683, ; 174: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 280
	i32 1178241025, ; 175: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 265
	i32 1202000627, ; 176: Microsoft.EntityFrameworkCore.Abstractions.dll => 0x47a512f3 => 174
	i32 1203215381, ; 177: pl/Microsoft.Maui.Controls.resources.dll => 0x47b79c15 => 318
	i32 1204270330, ; 178: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 226
	i32 1204575371, ; 179: Microsoft.Extensions.Caching.Memory.dll => 0x47cc5c8b => 176
	i32 1208641965, ; 180: System.Diagnostics.Process => 0x480a69ad => 28
	i32 1216849306, ; 181: Supabase.Realtime.dll => 0x4887a59a => 209
	i32 1219128291, ; 182: System.IO.IsolatedStorage => 0x48aa6be3 => 51
	i32 1219540809, ; 183: Supabase.Functions.dll => 0x48b0b749 => 206
	i32 1234928153, ; 184: nb/Microsoft.Maui.Controls.resources.dll => 0x499b8219 => 316
	i32 1243150071, ; 185: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x4a18f6f7 => 285
	i32 1253011324, ; 186: Microsoft.Win32.Registry => 0x4aaf6f7c => 5
	i32 1260983243, ; 187: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 300
	i32 1264511973, ; 188: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 275
	i32 1267360935, ; 189: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 279
	i32 1273260888, ; 190: Xamarin.AndroidX.Collection.Ktx => 0x4be46b58 => 231
	i32 1275534314, ; 191: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 296
	i32 1278448581, ; 192: Xamarin.AndroidX.Annotation.Jvm => 0x4c3393c5 => 223
	i32 1292207520, ; 193: SQLitePCLRaw.core.dll => 0x4d0585a0 => 201
	i32 1293217323, ; 194: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 242
	i32 1309188875, ; 195: System.Private.DataContractSerialization => 0x4e08a30b => 84
	i32 1322716291, ; 196: Xamarin.AndroidX.Window.dll => 0x4ed70c83 => 284
	i32 1324164729, ; 197: System.Linq => 0x4eed2679 => 60
	i32 1335329327, ; 198: System.Runtime.Serialization.Json.dll => 0x4f97822f => 111
	i32 1336984896, ; 199: Supabase.Core => 0x4fb0c540 => 205
	i32 1364015309, ; 200: System.IO => 0x514d38cd => 56
	i32 1373134921, ; 201: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 330
	i32 1376866003, ; 202: Xamarin.AndroidX.SavedState => 0x52114ed3 => 271
	i32 1379779777, ; 203: System.Resources.ResourceManager => 0x523dc4c1 => 98
	i32 1402170036, ; 204: System.Configuration.dll => 0x53936ab4 => 19
	i32 1406073936, ; 205: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 235
	i32 1408764838, ; 206: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 110
	i32 1411638395, ; 207: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 100
	i32 1422545099, ; 208: System.Runtime.CompilerServices.VisualC => 0x54ca50cb => 101
	i32 1430672901, ; 209: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 298
	i32 1434145427, ; 210: System.Runtime.Handles => 0x557b5293 => 103
	i32 1435222561, ; 211: Xamarin.Google.Crypto.Tink.Android.dll => 0x558bc221 => 288
	i32 1439761251, ; 212: System.Net.Quic.dll => 0x55d10363 => 70
	i32 1452070440, ; 213: System.Formats.Asn1.dll => 0x568cd628 => 37
	i32 1453312822, ; 214: System.Diagnostics.Tools.dll => 0x569fcb36 => 31
	i32 1457743152, ; 215: System.Runtime.Extensions.dll => 0x56e36530 => 102
	i32 1458022317, ; 216: System.Net.Security.dll => 0x56e7a7ad => 72
	i32 1460893475, ; 217: System.IdentityModel.Tokens.Jwt => 0x57137723 => 212
	i32 1461004990, ; 218: es\Microsoft.Maui.Controls.resources => 0x57152abe => 304
	i32 1461234159, ; 219: System.Collections.Immutable.dll => 0x5718a9ef => 9
	i32 1461719063, ; 220: System.Security.Cryptography.OpenSsl => 0x57201017 => 122
	i32 1462112819, ; 221: System.IO.Compression.dll => 0x57261233 => 45
	i32 1469204771, ; 222: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 225
	i32 1470490898, ; 223: Microsoft.Extensions.Primitives => 0x57a5e912 => 185
	i32 1479771757, ; 224: System.Collections.Immutable => 0x5833866d => 9
	i32 1480492111, ; 225: System.IO.Compression.Brotli.dll => 0x583e844f => 42
	i32 1487239319, ; 226: Microsoft.Win32.Primitives => 0x58a57897 => 4
	i32 1490025113, ; 227: Xamarin.AndroidX.SavedState.SavedState.Ktx.dll => 0x58cffa99 => 272
	i32 1493001747, ; 228: hi/Microsoft.Maui.Controls.resources.dll => 0x58fd6613 => 308
	i32 1498168481, ; 229: Microsoft.IdentityModel.JsonWebTokens.dll => 0x594c3ca1 => 187
	i32 1514721132, ; 230: el/Microsoft.Maui.Controls.resources.dll => 0x5a48cf6c => 303
	i32 1516168485, ; 231: Supabase.Gotrue => 0x5a5ee525 => 207
	i32 1536373174, ; 232: System.Diagnostics.TextWriterTraceListener => 0x5b9331b6 => 30
	i32 1543031311, ; 233: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 137
	i32 1543355203, ; 234: System.Reflection.Emit.dll => 0x5bfdbb43 => 91
	i32 1550322496, ; 235: System.Reflection.Extensions.dll => 0x5c680b40 => 92
	i32 1551623176, ; 236: sk/Microsoft.Maui.Controls.resources.dll => 0x5c7be408 => 323
	i32 1551954004, ; 237: Microsoft.IO.RecyclableMemoryStream.dll => 0x5c80f054 => 190
	i32 1565862583, ; 238: System.IO.FileSystem.Primitives => 0x5d552ab7 => 48
	i32 1566207040, ; 239: System.Threading.Tasks.Dataflow.dll => 0x5d5a6c40 => 140
	i32 1573704789, ; 240: System.Runtime.Serialization.Json => 0x5dccd455 => 111
	i32 1580037396, ; 241: System.Threading.Overlapped => 0x5e2d7514 => 139
	i32 1582372066, ; 242: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 241
	i32 1592978981, ; 243: System.Runtime.Serialization.dll => 0x5ef2ee25 => 114
	i32 1597949149, ; 244: Xamarin.Google.ErrorProne.Annotations => 0x5f3ec4dd => 289
	i32 1601112923, ; 245: System.Xml.Serialization => 0x5f6f0b5b => 156
	i32 1603525486, ; 246: Microsoft.Maui.Controls.HotReload.Forms.dll => 0x5f93db6e => 332
	i32 1604827217, ; 247: System.Net.WebClient => 0x5fa7b851 => 75
	i32 1618516317, ; 248: System.Net.WebSockets.Client.dll => 0x6078995d => 78
	i32 1622152042, ; 249: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 261
	i32 1622358360, ; 250: System.Dynamic.Runtime => 0x60b33958 => 36
	i32 1624863272, ; 251: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 283
	i32 1635184631, ; 252: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 245
	i32 1636350590, ; 253: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 238
	i32 1639515021, ; 254: System.Net.Http.dll => 0x61b9038d => 63
	i32 1639986890, ; 255: System.Text.RegularExpressions => 0x61c036ca => 137
	i32 1641389582, ; 256: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 15
	i32 1657153582, ; 257: System.Runtime => 0x62c6282e => 115
	i32 1658241508, ; 258: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 277
	i32 1658251792, ; 259: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 286
	i32 1670060433, ; 260: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 233
	i32 1675553242, ; 261: System.IO.FileSystem.DriveInfo.dll => 0x63dee9da => 47
	i32 1677501392, ; 262: System.Net.Primitives.dll => 0x63fca3d0 => 69
	i32 1678508291, ; 263: System.Net.WebSockets => 0x640c0103 => 79
	i32 1679769178, ; 264: System.Security.Cryptography => 0x641f3e5a => 125
	i32 1689493916, ; 265: Microsoft.EntityFrameworkCore.dll => 0x64b3a19c => 173
	i32 1691477237, ; 266: System.Reflection.Metadata => 0x64d1e4f5 => 93
	i32 1696967625, ; 267: System.Security.Cryptography.Csp => 0x6525abc9 => 120
	i32 1698840827, ; 268: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 293
	i32 1701541528, ; 269: System.Diagnostics.Debug.dll => 0x656b7698 => 26
	i32 1711441057, ; 270: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 202
	i32 1720223769, ; 271: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x66888819 => 254
	i32 1726116996, ; 272: System.Reflection.dll => 0x66e27484 => 96
	i32 1728033016, ; 273: System.Diagnostics.FileVersionInfo.dll => 0x66ffb0f8 => 27
	i32 1729485958, ; 274: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 229
	i32 1736233607, ; 275: ro/Microsoft.Maui.Controls.resources.dll => 0x677cd287 => 321
	i32 1743415430, ; 276: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 299
	i32 1744735666, ; 277: System.Transactions.Local.dll => 0x67fe8db2 => 148
	i32 1746316138, ; 278: Mono.Android.Export => 0x6816ab6a => 168
	i32 1750313021, ; 279: Microsoft.Win32.Primitives.dll => 0x6853a83d => 4
	i32 1758240030, ; 280: System.Resources.Reader.dll => 0x68cc9d1e => 97
	i32 1763938596, ; 281: System.Diagnostics.TraceSource.dll => 0x69239124 => 32
	i32 1765942094, ; 282: System.Reflection.Extensions => 0x6942234e => 92
	i32 1766324549, ; 283: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 276
	i32 1770582343, ; 284: Microsoft.Extensions.Logging.dll => 0x6988f147 => 181
	i32 1776026572, ; 285: System.Core.dll => 0x69dc03cc => 21
	i32 1777075843, ; 286: System.Globalization.Extensions.dll => 0x69ec0683 => 40
	i32 1780572499, ; 287: Mono.Android.Runtime.dll => 0x6a216153 => 169
	i32 1782862114, ; 288: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 315
	i32 1788241197, ; 289: Xamarin.AndroidX.Fragment => 0x6a96652d => 247
	i32 1793755602, ; 290: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 307
	i32 1808609942, ; 291: Xamarin.AndroidX.Loader => 0x6bcd3296 => 261
	i32 1813058853, ; 292: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 292
	i32 1813201214, ; 293: Xamarin.Google.Android.Material => 0x6c13413e => 286
	i32 1818569960, ; 294: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 266
	i32 1818787751, ; 295: Microsoft.VisualBasic.Core => 0x6c687fa7 => 2
	i32 1824175904, ; 296: System.Text.Encoding.Extensions => 0x6cbab720 => 133
	i32 1824722060, ; 297: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 110
	i32 1827303595, ; 298: Microsoft.VisualStudio.DesignTools.TapContract => 0x6cea70ab => 334
	i32 1828688058, ; 299: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 182
	i32 1842015223, ; 300: uk/Microsoft.Maui.Controls.resources.dll => 0x6dcaebf7 => 327
	i32 1847515442, ; 301: Xamarin.Android.Glide.Annotations => 0x6e1ed932 => 216
	i32 1853025655, ; 302: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 324
	i32 1858542181, ; 303: System.Linq.Expressions => 0x6ec71a65 => 57
	i32 1870277092, ; 304: System.Reflection.Primitives => 0x6f7a29e4 => 94
	i32 1875935024, ; 305: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 306
	i32 1879696579, ; 306: System.Formats.Tar.dll => 0x7009e4c3 => 38
	i32 1885316902, ; 307: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 227
	i32 1885918049, ; 308: Microsoft.VisualStudio.DesignTools.TapContract.dll => 0x7068d361 => 334
	i32 1888955245, ; 309: System.Diagnostics.Contracts => 0x70972b6d => 25
	i32 1889954781, ; 310: System.Reflection.Metadata.dll => 0x70a66bdd => 93
	i32 1898237753, ; 311: System.Reflection.DispatchProxy => 0x7124cf39 => 88
	i32 1900610850, ; 312: System.Resources.ResourceManager.dll => 0x71490522 => 98
	i32 1910275211, ; 313: System.Collections.NonGeneric.dll => 0x71dc7c8b => 10
	i32 1939592360, ; 314: System.Private.Xml.Linq => 0x739bd4a8 => 86
	i32 1956758971, ; 315: System.Resources.Writer => 0x74a1c5bb => 99
	i32 1961813231, ; 316: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x74eee4ef => 273
	i32 1968388702, ; 317: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 177
	i32 1983156543, ; 318: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 293
	i32 1985761444, ; 319: Xamarin.Android.Glide.GifDecoder => 0x765c50a4 => 218
	i32 1986222447, ; 320: Microsoft.IdentityModel.Tokens.dll => 0x7663596f => 189
	i32 1993527096, ; 321: MusicianAssistantMobile => 0x76d2cf38 => 0
	i32 2003115576, ; 322: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 303
	i32 2011961780, ; 323: System.Buffers.dll => 0x77ec19b4 => 7
	i32 2018526534, ; 324: Supabase.Gotrue.dll => 0x78504546 => 207
	i32 2019465201, ; 325: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 258
	i32 2025202353, ; 326: ar/Microsoft.Maui.Controls.resources.dll => 0x78b622b1 => 298
	i32 2031763787, ; 327: Xamarin.Android.Glide => 0x791a414b => 215
	i32 2045470958, ; 328: System.Private.Xml => 0x79eb68ee => 87
	i32 2055257422, ; 329: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 253
	i32 2060060697, ; 330: System.Windows.dll => 0x7aca0819 => 153
	i32 2066184531, ; 331: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 302
	i32 2070888862, ; 332: System.Diagnostics.TraceSource => 0x7b6f419e => 32
	i32 2079903147, ; 333: System.Runtime.dll => 0x7bf8cdab => 115
	i32 2090596640, ; 334: System.Numerics.Vectors => 0x7c9bf920 => 81
	i32 2103459038, ; 335: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 203
	i32 2127167465, ; 336: System.Console => 0x7ec9ffe9 => 20
	i32 2128198166, ; 337: Supabase.Realtime => 0x7ed9ba16 => 209
	i32 2138252982, ; 338: Supabase => 0x7f7326b6 => 204
	i32 2142473426, ; 339: System.Collections.Specialized => 0x7fb38cd2 => 11
	i32 2143465592, ; 340: Microsoft.IO.RecyclableMemoryStream => 0x7fc2b078 => 190
	i32 2143790110, ; 341: System.Xml.XmlSerializer.dll => 0x7fc7a41e => 161
	i32 2146852085, ; 342: Microsoft.VisualBasic.dll => 0x7ff65cf5 => 3
	i32 2159891885, ; 343: Microsoft.Maui => 0x80bd55ad => 194
	i32 2169148018, ; 344: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 310
	i32 2181898931, ; 345: Microsoft.Extensions.Options.dll => 0x820d22b3 => 184
	i32 2192057212, ; 346: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 182
	i32 2193016926, ; 347: System.ObjectModel.dll => 0x82b6c85e => 83
	i32 2201107256, ; 348: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 297
	i32 2201231467, ; 349: System.Net.Http => 0x8334206b => 63
	i32 2207618523, ; 350: it\Microsoft.Maui.Controls.resources => 0x839595db => 312
	i32 2217644978, ; 351: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 280
	i32 2222056684, ; 352: System.Threading.Tasks.Parallel => 0x8471e4ec => 142
	i32 2244775296, ; 353: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 262
	i32 2252106437, ; 354: System.Xml.Serialization.dll => 0x863c6ac5 => 156
	i32 2252897993, ; 355: Microsoft.EntityFrameworkCore => 0x86487ec9 => 173
	i32 2256313426, ; 356: System.Globalization.Extensions => 0x867c9c52 => 40
	i32 2265110946, ; 357: System.Security.AccessControl.dll => 0x8702d9a2 => 116
	i32 2266799131, ; 358: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 178
	i32 2267999099, ; 359: Xamarin.Android.Glide.DiskLruCache.dll => 0x872eeb7b => 217
	i32 2270573516, ; 360: fr/Microsoft.Maui.Controls.resources.dll => 0x875633cc => 306
	i32 2279755925, ; 361: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 269
	i32 2293034957, ; 362: System.ServiceModel.Web.dll => 0x88acefcd => 130
	i32 2295906218, ; 363: System.Net.Sockets => 0x88d8bfaa => 74
	i32 2298471582, ; 364: System.Net.Mail => 0x88ffe49e => 65
	i32 2303942373, ; 365: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 316
	i32 2305521784, ; 366: System.Private.CoreLib.dll => 0x896b7878 => 171
	i32 2315684594, ; 367: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 221
	i32 2320631194, ; 368: System.Threading.Tasks.Parallel.dll => 0x8a52059a => 142
	i32 2340441535, ; 369: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 105
	i32 2344264397, ; 370: System.ValueTuple => 0x8bbaa2cd => 150
	i32 2353062107, ; 371: System.Net.Primitives => 0x8c40e0db => 69
	i32 2368005991, ; 372: System.Xml.ReaderWriter.dll => 0x8d24e767 => 155
	i32 2369706906, ; 373: Microsoft.IdentityModel.Logging => 0x8d3edb9a => 188
	i32 2371007202, ; 374: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 177
	i32 2378619854, ; 375: System.Security.Cryptography.Csp.dll => 0x8dc6dbce => 120
	i32 2383496789, ; 376: System.Security.Principal.Windows.dll => 0x8e114655 => 126
	i32 2395872292, ; 377: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 311
	i32 2401565422, ; 378: System.Web.HttpUtility => 0x8f24faee => 151
	i32 2403452196, ; 379: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 244
	i32 2409983638, ; 380: Microsoft.VisualStudio.DesignTools.MobileTapContracts.dll => 0x8fa56e96 => 333
	i32 2421380589, ; 381: System.Threading.Tasks.Dataflow => 0x905355ed => 140
	i32 2423080555, ; 382: Xamarin.AndroidX.Collection.Ktx.dll => 0x906d466b => 231
	i32 2427813419, ; 383: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 308
	i32 2435356389, ; 384: System.Console.dll => 0x912896e5 => 20
	i32 2435904999, ; 385: System.ComponentModel.DataAnnotations.dll => 0x9130f5e7 => 14
	i32 2454642406, ; 386: System.Text.Encoding.dll => 0x924edee6 => 134
	i32 2458678730, ; 387: System.Net.Sockets.dll => 0x928c75ca => 74
	i32 2459001652, ; 388: System.Linq.Parallel.dll => 0x92916334 => 58
	i32 2465273461, ; 389: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 200
	i32 2465532216, ; 390: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 234
	i32 2471841756, ; 391: netstandard.dll => 0x93554fdc => 166
	i32 2475788418, ; 392: Java.Interop.dll => 0x93918882 => 167
	i32 2480646305, ; 393: Microsoft.Maui.Controls => 0x93dba8a1 => 192
	i32 2483903535, ; 394: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 15
	i32 2484371297, ; 395: System.Net.ServicePoint => 0x94147f61 => 73
	i32 2490993605, ; 396: System.AppContext.dll => 0x94798bc5 => 6
	i32 2501346920, ; 397: System.Data.DataSetExtensions => 0x95178668 => 23
	i32 2505896520, ; 398: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 256
	i32 2522472828, ; 399: Xamarin.Android.Glide.dll => 0x9659e17c => 215
	i32 2538310050, ; 400: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 90
	i32 2550873716, ; 401: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 309
	i32 2562349572, ; 402: Microsoft.CSharp => 0x98ba5a04 => 1
	i32 2570120770, ; 403: System.Text.Encodings.Web => 0x9930ee42 => 135
	i32 2581783588, ; 404: Xamarin.AndroidX.Lifecycle.Runtime.Ktx => 0x99e2e424 => 257
	i32 2581819634, ; 405: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 279
	i32 2585220780, ; 406: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 133
	i32 2585805581, ; 407: System.Net.Ping => 0x9a20430d => 68
	i32 2589602615, ; 408: System.Threading.ThreadPool => 0x9a5a3337 => 145
	i32 2593496499, ; 409: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 318
	i32 2605712449, ; 410: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 297
	i32 2615233544, ; 411: Xamarin.AndroidX.Fragment.Ktx => 0x9be14c08 => 248
	i32 2616218305, ; 412: Microsoft.Extensions.Logging.Debug.dll => 0x9bf052c1 => 183
	i32 2617129537, ; 413: System.Private.Xml.dll => 0x9bfe3a41 => 87
	i32 2618712057, ; 414: System.Reflection.TypeExtensions.dll => 0x9c165ff9 => 95
	i32 2620871830, ; 415: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 238
	i32 2624644809, ; 416: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 243
	i32 2626831493, ; 417: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 313
	i32 2627185994, ; 418: System.Diagnostics.TextWriterTraceListener.dll => 0x9c97ad4a => 30
	i32 2629843544, ; 419: System.IO.Compression.ZipFile.dll => 0x9cc03a58 => 44
	i32 2633051222, ; 420: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 252
	i32 2640290731, ; 421: Microsoft.IdentityModel.Logging.dll => 0x9d5fa3ab => 188
	i32 2663391936, ; 422: Xamarin.Android.Glide.DiskLruCache => 0x9ec022c0 => 217
	i32 2663698177, ; 423: System.Runtime.Loader => 0x9ec4cf01 => 108
	i32 2664396074, ; 424: System.Xml.XDocument.dll => 0x9ecf752a => 157
	i32 2665622720, ; 425: System.Drawing.Primitives => 0x9ee22cc0 => 34
	i32 2676780864, ; 426: System.Data.Common.dll => 0x9f8c6f40 => 22
	i32 2686887180, ; 427: System.Runtime.Serialization.Xml.dll => 0xa026a50c => 113
	i32 2693849962, ; 428: System.IO.dll => 0xa090e36a => 56
	i32 2701096212, ; 429: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 277
	i32 2715334215, ; 430: System.Threading.Tasks.dll => 0xa1d8b647 => 143
	i32 2717744543, ; 431: System.Security.Claims => 0xa1fd7d9f => 117
	i32 2719963679, ; 432: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 119
	i32 2724373263, ; 433: System.Runtime.Numerics.dll => 0xa262a30f => 109
	i32 2732626843, ; 434: Xamarin.AndroidX.Activity => 0xa2e0939b => 219
	i32 2735172069, ; 435: System.Threading.Channels => 0xa30769e5 => 138
	i32 2737747696, ; 436: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 225
	i32 2740948882, ; 437: System.IO.Pipes.AccessControl => 0xa35f8f92 => 53
	i32 2748088231, ; 438: System.Runtime.InteropServices.JavaScript => 0xa3cc7fa7 => 104
	i32 2752995522, ; 439: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 319
	i32 2758225723, ; 440: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 193
	i32 2764765095, ; 441: Microsoft.Maui.dll => 0xa4caf7a7 => 194
	i32 2765824710, ; 442: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 132
	i32 2770495804, ; 443: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 291
	i32 2778768386, ; 444: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 282
	i32 2779977773, ; 445: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 270
	i32 2785988530, ; 446: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 325
	i32 2788224221, ; 447: Xamarin.AndroidX.Fragment.Ktx.dll => 0xa630ecdd => 248
	i32 2801831435, ; 448: Microsoft.Maui.Graphics => 0xa7008e0b => 196
	i32 2803228030, ; 449: System.Xml.XPath.XDocument.dll => 0xa715dd7e => 158
	i32 2806116107, ; 450: es/Microsoft.Maui.Controls.resources.dll => 0xa741ef0b => 304
	i32 2810250172, ; 451: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 235
	i32 2819470561, ; 452: System.Xml.dll => 0xa80db4e1 => 162
	i32 2821205001, ; 453: System.ServiceProcess.dll => 0xa8282c09 => 131
	i32 2821294376, ; 454: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 270
	i32 2824502124, ; 455: System.Xml.XmlDocument => 0xa85a7b6c => 160
	i32 2831556043, ; 456: nl/Microsoft.Maui.Controls.resources.dll => 0xa8c61dcb => 317
	i32 2838993487, ; 457: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll => 0xa9379a4f => 259
	i32 2849599387, ; 458: System.Threading.Overlapped.dll => 0xa9d96f9b => 139
	i32 2853208004, ; 459: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 282
	i32 2855708567, ; 460: Xamarin.AndroidX.Transition => 0xaa36a797 => 278
	i32 2861098320, ; 461: Mono.Android.Export.dll => 0xaa88e550 => 168
	i32 2861189240, ; 462: Microsoft.Maui.Essentials => 0xaa8a4878 => 195
	i32 2870099610, ; 463: Xamarin.AndroidX.Activity.Ktx.dll => 0xab123e9a => 220
	i32 2875164099, ; 464: Jsr305Binding.dll => 0xab5f85c3 => 287
	i32 2875220617, ; 465: System.Globalization.Calendars.dll => 0xab606289 => 39
	i32 2884993177, ; 466: Xamarin.AndroidX.ExifInterface => 0xabf58099 => 246
	i32 2887636118, ; 467: System.Net.dll => 0xac1dd496 => 80
	i32 2899753641, ; 468: System.IO.UnmanagedMemoryStream => 0xacd6baa9 => 55
	i32 2900621748, ; 469: System.Dynamic.Runtime.dll => 0xace3f9b4 => 36
	i32 2901442782, ; 470: System.Reflection => 0xacf080de => 96
	i32 2905242038, ; 471: mscorlib.dll => 0xad2a79b6 => 165
	i32 2909740682, ; 472: System.Private.CoreLib => 0xad6f1e8a => 171
	i32 2916838712, ; 473: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 283
	i32 2919462931, ; 474: System.Numerics.Vectors.dll => 0xae037813 => 81
	i32 2921128767, ; 475: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 222
	i32 2936416060, ; 476: System.Resources.Reader => 0xaf06273c => 97
	i32 2940926066, ; 477: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 29
	i32 2942453041, ; 478: System.Xml.XPath.XDocument => 0xaf624531 => 158
	i32 2959614098, ; 479: System.ComponentModel.dll => 0xb0682092 => 18
	i32 2968338931, ; 480: System.Security.Principal.Windows => 0xb0ed41f3 => 126
	i32 2972252294, ; 481: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 118
	i32 2978675010, ; 482: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 242
	i32 2987532451, ; 483: Xamarin.AndroidX.Security.SecurityCrypto => 0xb21220a3 => 273
	i32 2996846495, ; 484: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 255
	i32 3016983068, ; 485: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 275
	i32 3023353419, ; 486: WindowsBase.dll => 0xb434b64b => 164
	i32 3024354802, ; 487: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 250
	i32 3038032645, ; 488: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 335
	i32 3056245963, ; 489: Xamarin.AndroidX.SavedState.SavedState.Ktx => 0xb62a9ccb => 272
	i32 3057625584, ; 490: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 263
	i32 3059408633, ; 491: Mono.Android.Runtime => 0xb65adef9 => 169
	i32 3059793426, ; 492: System.ComponentModel.Primitives => 0xb660be12 => 16
	i32 3069363400, ; 493: Microsoft.Extensions.Caching.Abstractions.dll => 0xb6f2c4c8 => 175
	i32 3075834255, ; 494: System.Threading.Tasks => 0xb755818f => 143
	i32 3077302341, ; 495: hu/Microsoft.Maui.Controls.resources.dll => 0xb76be845 => 310
	i32 3084678329, ; 496: Microsoft.IdentityModel.Tokens => 0xb7dc74b9 => 189
	i32 3090735792, ; 497: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 124
	i32 3099081453, ; 498: MimeMapping.dll => 0xb8b83aed => 197
	i32 3099732863, ; 499: System.Security.Claims.dll => 0xb8c22b7f => 117
	i32 3103600923, ; 500: System.Formats.Asn1 => 0xb8fd311b => 37
	i32 3111772706, ; 501: System.Runtime.Serialization => 0xb979e222 => 114
	i32 3121463068, ; 502: System.IO.FileSystem.AccessControl.dll => 0xba0dbf1c => 46
	i32 3124832203, ; 503: System.Threading.Tasks.Extensions => 0xba4127cb => 141
	i32 3132293585, ; 504: System.Security.AccessControl => 0xbab301d1 => 116
	i32 3138360719, ; 505: Supabase.Postgrest.dll => 0xbb0f958f => 208
	i32 3147165239, ; 506: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 33
	i32 3148237826, ; 507: GoogleGson.dll => 0xbba64c02 => 172
	i32 3159123045, ; 508: System.Reflection.Primitives.dll => 0xbc4c6465 => 94
	i32 3160747431, ; 509: System.IO.MemoryMappedFiles => 0xbc652da7 => 52
	i32 3178803400, ; 510: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 264
	i32 3192346100, ; 511: System.Security.SecureString => 0xbe4755f4 => 128
	i32 3193515020, ; 512: System.Web => 0xbe592c0c => 152
	i32 3195844289, ; 513: Microsoft.Extensions.Caching.Abstractions => 0xbe7cb6c1 => 175
	i32 3204380047, ; 514: System.Data.dll => 0xbefef58f => 24
	i32 3209718065, ; 515: System.Xml.XmlDocument.dll => 0xbf506931 => 160
	i32 3211777861, ; 516: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 241
	i32 3220365878, ; 517: System.Threading => 0xbff2e236 => 147
	i32 3226221578, ; 518: System.Runtime.Handles.dll => 0xc04c3c0a => 103
	i32 3251039220, ; 519: System.Reflection.DispatchProxy.dll => 0xc1c6ebf4 => 88
	i32 3258312781, ; 520: Xamarin.AndroidX.CardView => 0xc235e84d => 229
	i32 3265493905, ; 521: System.Linq.Queryable.dll => 0xc2a37b91 => 59
	i32 3265893370, ; 522: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 141
	i32 3277815716, ; 523: System.Resources.Writer.dll => 0xc35f7fa4 => 99
	i32 3279906254, ; 524: Microsoft.Win32.Registry.dll => 0xc37f65ce => 5
	i32 3280506390, ; 525: System.ComponentModel.Annotations.dll => 0xc3888e16 => 13
	i32 3286872994, ; 526: SQLite-net.dll => 0xc3e9b3a2 => 199
	i32 3290767353, ; 527: System.Security.Cryptography.Encoding => 0xc4251ff9 => 121
	i32 3299363146, ; 528: System.Text.Encoding => 0xc4a8494a => 134
	i32 3303498502, ; 529: System.Diagnostics.FileVersionInfo => 0xc4e76306 => 27
	i32 3305363605, ; 530: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 305
	i32 3312457198, ; 531: Microsoft.IdentityModel.JsonWebTokens => 0xc57015ee => 187
	i32 3316684772, ; 532: System.Net.Requests.dll => 0xc5b097e4 => 71
	i32 3317135071, ; 533: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 239
	i32 3317144872, ; 534: System.Data => 0xc5b79d28 => 24
	i32 3340431453, ; 535: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 227
	i32 3345895724, ; 536: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 268
	i32 3346324047, ; 537: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 265
	i32 3357674450, ; 538: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 322
	i32 3358260929, ; 539: System.Text.Json => 0xc82afec1 => 136
	i32 3360279109, ; 540: SQLitePCLRaw.core => 0xc849ca45 => 201
	i32 3362336904, ; 541: Xamarin.AndroidX.Activity.Ktx => 0xc8693088 => 220
	i32 3362522851, ; 542: Xamarin.AndroidX.Core => 0xc86c06e3 => 236
	i32 3366347497, ; 543: Java.Interop => 0xc8a662e9 => 167
	i32 3374999561, ; 544: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 269
	i32 3381016424, ; 545: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 301
	i32 3395150330, ; 546: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 100
	i32 3403906625, ; 547: System.Security.Cryptography.OpenSsl.dll => 0xcae37e41 => 122
	i32 3405233483, ; 548: Xamarin.AndroidX.CustomView.PoolingContainer => 0xcaf7bd4b => 240
	i32 3428513518, ; 549: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 179
	i32 3429136800, ; 550: System.Xml => 0xcc6479a0 => 162
	i32 3430777524, ; 551: netstandard => 0xcc7d82b4 => 166
	i32 3441283291, ; 552: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 243
	i32 3445260447, ; 553: System.Formats.Tar => 0xcd5a809f => 38
	i32 3452344032, ; 554: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 191
	i32 3463511458, ; 555: hr/Microsoft.Maui.Controls.resources.dll => 0xce70fda2 => 309
	i32 3471940407, ; 556: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 17
	i32 3476120550, ; 557: Mono.Android => 0xcf3163e6 => 170
	i32 3479583265, ; 558: ru/Microsoft.Maui.Controls.resources.dll => 0xcf663a21 => 322
	i32 3484440000, ; 559: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 321
	i32 3485117614, ; 560: System.Text.Json.dll => 0xcfbaacae => 136
	i32 3486566296, ; 561: System.Transactions => 0xcfd0c798 => 149
	i32 3493954962, ; 562: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 232
	i32 3509114376, ; 563: System.Xml.Linq => 0xd128d608 => 154
	i32 3515174580, ; 564: System.Security.dll => 0xd1854eb4 => 129
	i32 3530912306, ; 565: System.Configuration => 0xd2757232 => 19
	i32 3539954161, ; 566: System.Net.HttpListener => 0xd2ff69f1 => 64
	i32 3560100363, ; 567: System.Threading.Timer => 0xd432d20b => 146
	i32 3570554715, ; 568: System.IO.FileSystem.AccessControl => 0xd4d2575b => 46
	i32 3580758918, ; 569: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 329
	i32 3597029428, ; 570: Xamarin.Android.Glide.GifDecoder.dll => 0xd6665034 => 218
	i32 3598340787, ; 571: System.Net.WebSockets.Client => 0xd67a52b3 => 78
	i32 3607666123, ; 572: Supabase.Postgrest => 0xd7089dcb => 208
	i32 3608519521, ; 573: System.Linq.dll => 0xd715a361 => 60
	i32 3624195450, ; 574: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 105
	i32 3627220390, ; 575: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 267
	i32 3633644679, ; 576: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 222
	i32 3638274909, ; 577: System.IO.FileSystem.Primitives.dll => 0xd8dbab5d => 48
	i32 3641597786, ; 578: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 253
	i32 3643446276, ; 579: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 326
	i32 3643854240, ; 580: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 264
	i32 3645089577, ; 581: System.ComponentModel.DataAnnotations => 0xd943a729 => 14
	i32 3657292374, ; 582: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 178
	i32 3660523487, ; 583: System.Net.NetworkInformation => 0xda2f27df => 67
	i32 3672681054, ; 584: Mono.Android.dll => 0xdae8aa5e => 170
	i32 3676670898, ; 585: Microsoft.Maui.Controls.HotReload.Forms => 0xdb258bb2 => 332
	i32 3682565725, ; 586: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 228
	i32 3684561358, ; 587: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 232
	i32 3697841164, ; 588: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xdc68940c => 331
	i32 3700591436, ; 589: Microsoft.IdentityModel.Abstractions.dll => 0xdc928b4c => 186
	i32 3700866549, ; 590: System.Net.WebProxy.dll => 0xdc96bdf5 => 77
	i32 3706696989, ; 591: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 237
	i32 3716563718, ; 592: System.Runtime.Intrinsics => 0xdd864306 => 107
	i32 3718780102, ; 593: Xamarin.AndroidX.Annotation => 0xdda814c6 => 221
	i32 3724971120, ; 594: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 263
	i32 3731644420, ; 595: System.Reactive => 0xde6c6004 => 213
	i32 3732100267, ; 596: System.Net.NameResolution => 0xde7354ab => 66
	i32 3737834244, ; 597: System.Net.Http.Json.dll => 0xdecad304 => 62
	i32 3748608112, ; 598: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 211
	i32 3751444290, ; 599: System.Xml.XPath => 0xdf9a7f42 => 159
	i32 3754567612, ; 600: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 203
	i32 3786282454, ; 601: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 230
	i32 3792276235, ; 602: System.Collections.NonGeneric => 0xe2098b0b => 10
	i32 3800979733, ; 603: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 191
	i32 3802395368, ; 604: System.Collections.Specialized.dll => 0xe2a3f2e8 => 11
	i32 3819260425, ; 605: System.Net.WebProxy => 0xe3a54a09 => 77
	i32 3823082795, ; 606: System.Security.Cryptography.dll => 0xe3df9d2b => 125
	i32 3829621856, ; 607: System.Numerics.dll => 0xe4436460 => 82
	i32 3841636137, ; 608: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 180
	i32 3844307129, ; 609: System.Net.Mail.dll => 0xe52378b9 => 65
	i32 3849253459, ; 610: System.Runtime.InteropServices.dll => 0xe56ef253 => 106
	i32 3870376305, ; 611: System.Net.HttpListener.dll => 0xe6b14171 => 64
	i32 3873536506, ; 612: System.Security.Principal => 0xe6e179fa => 127
	i32 3875112723, ; 613: System.Security.Cryptography.Encoding.dll => 0xe6f98713 => 121
	i32 3876362041, ; 614: SQLite-net => 0xe70c9739 => 199
	i32 3885497537, ; 615: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 76
	i32 3885922214, ; 616: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 278
	i32 3888767677, ; 617: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 268
	i32 3889960447, ; 618: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xe7dc15ff => 330
	i32 3896106733, ; 619: System.Collections.Concurrent.dll => 0xe839deed => 8
	i32 3896760992, ; 620: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 236
	i32 3901907137, ; 621: Microsoft.VisualBasic.Core.dll => 0xe89260c1 => 2
	i32 3906640997, ; 622: Supabase.Storage.dll => 0xe8da9c65 => 210
	i32 3920810846, ; 623: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 43
	i32 3921031405, ; 624: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 281
	i32 3928044579, ; 625: System.Xml.ReaderWriter => 0xea213423 => 155
	i32 3930554604, ; 626: System.Security.Principal.dll => 0xea4780ec => 127
	i32 3931092270, ; 627: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 266
	i32 3945713374, ; 628: System.Data.DataSetExtensions.dll => 0xeb2ecede => 23
	i32 3953953790, ; 629: System.Text.Encoding.CodePages => 0xebac8bfe => 132
	i32 3955647286, ; 630: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 224
	i32 3959773229, ; 631: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 255
	i32 3980364293, ; 632: Supabase.Storage => 0xed3f8a05 => 210
	i32 3980434154, ; 633: th/Microsoft.Maui.Controls.resources.dll => 0xed409aea => 325
	i32 3987592930, ; 634: he/Microsoft.Maui.Controls.resources.dll => 0xedadd6e2 => 307
	i32 4003436829, ; 635: System.Diagnostics.Process.dll => 0xee9f991d => 28
	i32 4015948917, ; 636: Xamarin.AndroidX.Annotation.Jvm.dll => 0xef5e8475 => 223
	i32 4025784931, ; 637: System.Memory => 0xeff49a63 => 61
	i32 4046471985, ; 638: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 193
	i32 4054681211, ; 639: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 89
	i32 4068434129, ; 640: System.Private.Xml.Linq.dll => 0xf27f60d1 => 86
	i32 4073602200, ; 641: System.Threading.dll => 0xf2ce3c98 => 147
	i32 4094352644, ; 642: Microsoft.Maui.Essentials.dll => 0xf40add04 => 195
	i32 4099507663, ; 643: System.Drawing.dll => 0xf45985cf => 35
	i32 4100113165, ; 644: System.Private.Uri => 0xf462c30d => 85
	i32 4101593132, ; 645: Xamarin.AndroidX.Emoji2 => 0xf479582c => 244
	i32 4101842092, ; 646: Microsoft.Extensions.Caching.Memory => 0xf47d24ac => 176
	i32 4102112229, ; 647: pt/Microsoft.Maui.Controls.resources.dll => 0xf48143e5 => 320
	i32 4125707920, ; 648: ms/Microsoft.Maui.Controls.resources.dll => 0xf5e94e90 => 315
	i32 4126470640, ; 649: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 179
	i32 4127667938, ; 650: System.IO.FileSystem.Watcher => 0xf60736e2 => 49
	i32 4130442656, ; 651: System.AppContext => 0xf6318da0 => 6
	i32 4147896353, ; 652: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 89
	i32 4150914736, ; 653: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 327
	i32 4151237749, ; 654: System.Core => 0xf76edc75 => 21
	i32 4159265925, ; 655: System.Xml.XmlSerializer => 0xf7e95c85 => 161
	i32 4161255271, ; 656: System.Reflection.TypeExtensions => 0xf807b767 => 95
	i32 4164802419, ; 657: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 49
	i32 4181436372, ; 658: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 112
	i32 4182413190, ; 659: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 260
	i32 4182880526, ; 660: Microsoft.VisualStudio.DesignTools.MobileTapContracts => 0xf951b10e => 333
	i32 4185676441, ; 661: System.Security => 0xf97c5a99 => 129
	i32 4196529839, ; 662: System.Net.WebClient.dll => 0xfa21f6af => 75
	i32 4213026141, ; 663: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 211
	i32 4256097574, ; 664: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 237
	i32 4258378803, ; 665: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx => 0xfdd1b433 => 259
	i32 4260525087, ; 666: System.Buffers => 0xfdf2741f => 7
	i32 4263231520, ; 667: System.IdentityModel.Tokens.Jwt.dll => 0xfe1bc020 => 212
	i32 4271975918, ; 668: Microsoft.Maui.Controls.dll => 0xfea12dee => 192
	i32 4274976490, ; 669: System.Runtime.Numerics => 0xfecef6ea => 109
	i32 4292120959, ; 670: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 260
	i32 4294763496 ; 671: Xamarin.AndroidX.ExifInterface.dll => 0xfffce3e8 => 246
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [672 x i32] [
	i32 67, ; 0
	i32 66, ; 1
	i32 107, ; 2
	i32 256, ; 3
	i32 290, ; 4
	i32 47, ; 5
	i32 198, ; 6
	i32 79, ; 7
	i32 144, ; 8
	i32 29, ; 9
	i32 331, ; 10
	i32 123, ; 11
	i32 196, ; 12
	i32 101, ; 13
	i32 204, ; 14
	i32 274, ; 15
	i32 106, ; 16
	i32 274, ; 17
	i32 138, ; 18
	i32 294, ; 19
	i32 76, ; 20
	i32 123, ; 21
	i32 13, ; 22
	i32 197, ; 23
	i32 230, ; 24
	i32 131, ; 25
	i32 276, ; 26
	i32 150, ; 27
	i32 328, ; 28
	i32 329, ; 29
	i32 18, ; 30
	i32 228, ; 31
	i32 26, ; 32
	i32 250, ; 33
	i32 1, ; 34
	i32 58, ; 35
	i32 41, ; 36
	i32 90, ; 37
	i32 233, ; 38
	i32 146, ; 39
	i32 252, ; 40
	i32 249, ; 41
	i32 300, ; 42
	i32 53, ; 43
	i32 68, ; 44
	i32 328, ; 45
	i32 219, ; 46
	i32 82, ; 47
	i32 313, ; 48
	i32 251, ; 49
	i32 202, ; 50
	i32 312, ; 51
	i32 130, ; 52
	i32 54, ; 53
	i32 148, ; 54
	i32 73, ; 55
	i32 144, ; 56
	i32 61, ; 57
	i32 145, ; 58
	i32 335, ; 59
	i32 164, ; 60
	i32 324, ; 61
	i32 234, ; 62
	i32 12, ; 63
	i32 247, ; 64
	i32 124, ; 65
	i32 151, ; 66
	i32 112, ; 67
	i32 165, ; 68
	i32 163, ; 69
	i32 249, ; 70
	i32 186, ; 71
	i32 262, ; 72
	i32 83, ; 73
	i32 311, ; 74
	i32 305, ; 75
	i32 185, ; 76
	i32 149, ; 77
	i32 294, ; 78
	i32 59, ; 79
	i32 181, ; 80
	i32 50, ; 81
	i32 102, ; 82
	i32 113, ; 83
	i32 39, ; 84
	i32 287, ; 85
	i32 285, ; 86
	i32 119, ; 87
	i32 319, ; 88
	i32 51, ; 89
	i32 43, ; 90
	i32 213, ; 91
	i32 118, ; 92
	i32 239, ; 93
	i32 317, ; 94
	i32 245, ; 95
	i32 80, ; 96
	i32 135, ; 97
	i32 281, ; 98
	i32 226, ; 99
	i32 8, ; 100
	i32 72, ; 101
	i32 299, ; 102
	i32 154, ; 103
	i32 296, ; 104
	i32 153, ; 105
	i32 91, ; 106
	i32 291, ; 107
	i32 44, ; 108
	i32 314, ; 109
	i32 302, ; 110
	i32 295, ; 111
	i32 108, ; 112
	i32 128, ; 113
	i32 200, ; 114
	i32 25, ; 115
	i32 216, ; 116
	i32 71, ; 117
	i32 54, ; 118
	i32 214, ; 119
	i32 205, ; 120
	i32 45, ; 121
	i32 323, ; 122
	i32 184, ; 123
	i32 240, ; 124
	i32 22, ; 125
	i32 254, ; 126
	i32 85, ; 127
	i32 42, ; 128
	i32 159, ; 129
	i32 70, ; 130
	i32 267, ; 131
	i32 3, ; 132
	i32 41, ; 133
	i32 62, ; 134
	i32 16, ; 135
	i32 52, ; 136
	i32 206, ; 137
	i32 326, ; 138
	i32 290, ; 139
	i32 104, ; 140
	i32 198, ; 141
	i32 295, ; 142
	i32 0, ; 143
	i32 288, ; 144
	i32 251, ; 145
	i32 33, ; 146
	i32 157, ; 147
	i32 84, ; 148
	i32 31, ; 149
	i32 12, ; 150
	i32 50, ; 151
	i32 55, ; 152
	i32 271, ; 153
	i32 35, ; 154
	i32 180, ; 155
	i32 301, ; 156
	i32 289, ; 157
	i32 224, ; 158
	i32 34, ; 159
	i32 57, ; 160
	i32 258, ; 161
	i32 172, ; 162
	i32 17, ; 163
	i32 292, ; 164
	i32 214, ; 165
	i32 163, ; 166
	i32 314, ; 167
	i32 257, ; 168
	i32 183, ; 169
	i32 284, ; 170
	i32 174, ; 171
	i32 320, ; 172
	i32 152, ; 173
	i32 280, ; 174
	i32 265, ; 175
	i32 174, ; 176
	i32 318, ; 177
	i32 226, ; 178
	i32 176, ; 179
	i32 28, ; 180
	i32 209, ; 181
	i32 51, ; 182
	i32 206, ; 183
	i32 316, ; 184
	i32 285, ; 185
	i32 5, ; 186
	i32 300, ; 187
	i32 275, ; 188
	i32 279, ; 189
	i32 231, ; 190
	i32 296, ; 191
	i32 223, ; 192
	i32 201, ; 193
	i32 242, ; 194
	i32 84, ; 195
	i32 284, ; 196
	i32 60, ; 197
	i32 111, ; 198
	i32 205, ; 199
	i32 56, ; 200
	i32 330, ; 201
	i32 271, ; 202
	i32 98, ; 203
	i32 19, ; 204
	i32 235, ; 205
	i32 110, ; 206
	i32 100, ; 207
	i32 101, ; 208
	i32 298, ; 209
	i32 103, ; 210
	i32 288, ; 211
	i32 70, ; 212
	i32 37, ; 213
	i32 31, ; 214
	i32 102, ; 215
	i32 72, ; 216
	i32 212, ; 217
	i32 304, ; 218
	i32 9, ; 219
	i32 122, ; 220
	i32 45, ; 221
	i32 225, ; 222
	i32 185, ; 223
	i32 9, ; 224
	i32 42, ; 225
	i32 4, ; 226
	i32 272, ; 227
	i32 308, ; 228
	i32 187, ; 229
	i32 303, ; 230
	i32 207, ; 231
	i32 30, ; 232
	i32 137, ; 233
	i32 91, ; 234
	i32 92, ; 235
	i32 323, ; 236
	i32 190, ; 237
	i32 48, ; 238
	i32 140, ; 239
	i32 111, ; 240
	i32 139, ; 241
	i32 241, ; 242
	i32 114, ; 243
	i32 289, ; 244
	i32 156, ; 245
	i32 332, ; 246
	i32 75, ; 247
	i32 78, ; 248
	i32 261, ; 249
	i32 36, ; 250
	i32 283, ; 251
	i32 245, ; 252
	i32 238, ; 253
	i32 63, ; 254
	i32 137, ; 255
	i32 15, ; 256
	i32 115, ; 257
	i32 277, ; 258
	i32 286, ; 259
	i32 233, ; 260
	i32 47, ; 261
	i32 69, ; 262
	i32 79, ; 263
	i32 125, ; 264
	i32 173, ; 265
	i32 93, ; 266
	i32 120, ; 267
	i32 293, ; 268
	i32 26, ; 269
	i32 202, ; 270
	i32 254, ; 271
	i32 96, ; 272
	i32 27, ; 273
	i32 229, ; 274
	i32 321, ; 275
	i32 299, ; 276
	i32 148, ; 277
	i32 168, ; 278
	i32 4, ; 279
	i32 97, ; 280
	i32 32, ; 281
	i32 92, ; 282
	i32 276, ; 283
	i32 181, ; 284
	i32 21, ; 285
	i32 40, ; 286
	i32 169, ; 287
	i32 315, ; 288
	i32 247, ; 289
	i32 307, ; 290
	i32 261, ; 291
	i32 292, ; 292
	i32 286, ; 293
	i32 266, ; 294
	i32 2, ; 295
	i32 133, ; 296
	i32 110, ; 297
	i32 334, ; 298
	i32 182, ; 299
	i32 327, ; 300
	i32 216, ; 301
	i32 324, ; 302
	i32 57, ; 303
	i32 94, ; 304
	i32 306, ; 305
	i32 38, ; 306
	i32 227, ; 307
	i32 334, ; 308
	i32 25, ; 309
	i32 93, ; 310
	i32 88, ; 311
	i32 98, ; 312
	i32 10, ; 313
	i32 86, ; 314
	i32 99, ; 315
	i32 273, ; 316
	i32 177, ; 317
	i32 293, ; 318
	i32 218, ; 319
	i32 189, ; 320
	i32 0, ; 321
	i32 303, ; 322
	i32 7, ; 323
	i32 207, ; 324
	i32 258, ; 325
	i32 298, ; 326
	i32 215, ; 327
	i32 87, ; 328
	i32 253, ; 329
	i32 153, ; 330
	i32 302, ; 331
	i32 32, ; 332
	i32 115, ; 333
	i32 81, ; 334
	i32 203, ; 335
	i32 20, ; 336
	i32 209, ; 337
	i32 204, ; 338
	i32 11, ; 339
	i32 190, ; 340
	i32 161, ; 341
	i32 3, ; 342
	i32 194, ; 343
	i32 310, ; 344
	i32 184, ; 345
	i32 182, ; 346
	i32 83, ; 347
	i32 297, ; 348
	i32 63, ; 349
	i32 312, ; 350
	i32 280, ; 351
	i32 142, ; 352
	i32 262, ; 353
	i32 156, ; 354
	i32 173, ; 355
	i32 40, ; 356
	i32 116, ; 357
	i32 178, ; 358
	i32 217, ; 359
	i32 306, ; 360
	i32 269, ; 361
	i32 130, ; 362
	i32 74, ; 363
	i32 65, ; 364
	i32 316, ; 365
	i32 171, ; 366
	i32 221, ; 367
	i32 142, ; 368
	i32 105, ; 369
	i32 150, ; 370
	i32 69, ; 371
	i32 155, ; 372
	i32 188, ; 373
	i32 177, ; 374
	i32 120, ; 375
	i32 126, ; 376
	i32 311, ; 377
	i32 151, ; 378
	i32 244, ; 379
	i32 333, ; 380
	i32 140, ; 381
	i32 231, ; 382
	i32 308, ; 383
	i32 20, ; 384
	i32 14, ; 385
	i32 134, ; 386
	i32 74, ; 387
	i32 58, ; 388
	i32 200, ; 389
	i32 234, ; 390
	i32 166, ; 391
	i32 167, ; 392
	i32 192, ; 393
	i32 15, ; 394
	i32 73, ; 395
	i32 6, ; 396
	i32 23, ; 397
	i32 256, ; 398
	i32 215, ; 399
	i32 90, ; 400
	i32 309, ; 401
	i32 1, ; 402
	i32 135, ; 403
	i32 257, ; 404
	i32 279, ; 405
	i32 133, ; 406
	i32 68, ; 407
	i32 145, ; 408
	i32 318, ; 409
	i32 297, ; 410
	i32 248, ; 411
	i32 183, ; 412
	i32 87, ; 413
	i32 95, ; 414
	i32 238, ; 415
	i32 243, ; 416
	i32 313, ; 417
	i32 30, ; 418
	i32 44, ; 419
	i32 252, ; 420
	i32 188, ; 421
	i32 217, ; 422
	i32 108, ; 423
	i32 157, ; 424
	i32 34, ; 425
	i32 22, ; 426
	i32 113, ; 427
	i32 56, ; 428
	i32 277, ; 429
	i32 143, ; 430
	i32 117, ; 431
	i32 119, ; 432
	i32 109, ; 433
	i32 219, ; 434
	i32 138, ; 435
	i32 225, ; 436
	i32 53, ; 437
	i32 104, ; 438
	i32 319, ; 439
	i32 193, ; 440
	i32 194, ; 441
	i32 132, ; 442
	i32 291, ; 443
	i32 282, ; 444
	i32 270, ; 445
	i32 325, ; 446
	i32 248, ; 447
	i32 196, ; 448
	i32 158, ; 449
	i32 304, ; 450
	i32 235, ; 451
	i32 162, ; 452
	i32 131, ; 453
	i32 270, ; 454
	i32 160, ; 455
	i32 317, ; 456
	i32 259, ; 457
	i32 139, ; 458
	i32 282, ; 459
	i32 278, ; 460
	i32 168, ; 461
	i32 195, ; 462
	i32 220, ; 463
	i32 287, ; 464
	i32 39, ; 465
	i32 246, ; 466
	i32 80, ; 467
	i32 55, ; 468
	i32 36, ; 469
	i32 96, ; 470
	i32 165, ; 471
	i32 171, ; 472
	i32 283, ; 473
	i32 81, ; 474
	i32 222, ; 475
	i32 97, ; 476
	i32 29, ; 477
	i32 158, ; 478
	i32 18, ; 479
	i32 126, ; 480
	i32 118, ; 481
	i32 242, ; 482
	i32 273, ; 483
	i32 255, ; 484
	i32 275, ; 485
	i32 164, ; 486
	i32 250, ; 487
	i32 335, ; 488
	i32 272, ; 489
	i32 263, ; 490
	i32 169, ; 491
	i32 16, ; 492
	i32 175, ; 493
	i32 143, ; 494
	i32 310, ; 495
	i32 189, ; 496
	i32 124, ; 497
	i32 197, ; 498
	i32 117, ; 499
	i32 37, ; 500
	i32 114, ; 501
	i32 46, ; 502
	i32 141, ; 503
	i32 116, ; 504
	i32 208, ; 505
	i32 33, ; 506
	i32 172, ; 507
	i32 94, ; 508
	i32 52, ; 509
	i32 264, ; 510
	i32 128, ; 511
	i32 152, ; 512
	i32 175, ; 513
	i32 24, ; 514
	i32 160, ; 515
	i32 241, ; 516
	i32 147, ; 517
	i32 103, ; 518
	i32 88, ; 519
	i32 229, ; 520
	i32 59, ; 521
	i32 141, ; 522
	i32 99, ; 523
	i32 5, ; 524
	i32 13, ; 525
	i32 199, ; 526
	i32 121, ; 527
	i32 134, ; 528
	i32 27, ; 529
	i32 305, ; 530
	i32 187, ; 531
	i32 71, ; 532
	i32 239, ; 533
	i32 24, ; 534
	i32 227, ; 535
	i32 268, ; 536
	i32 265, ; 537
	i32 322, ; 538
	i32 136, ; 539
	i32 201, ; 540
	i32 220, ; 541
	i32 236, ; 542
	i32 167, ; 543
	i32 269, ; 544
	i32 301, ; 545
	i32 100, ; 546
	i32 122, ; 547
	i32 240, ; 548
	i32 179, ; 549
	i32 162, ; 550
	i32 166, ; 551
	i32 243, ; 552
	i32 38, ; 553
	i32 191, ; 554
	i32 309, ; 555
	i32 17, ; 556
	i32 170, ; 557
	i32 322, ; 558
	i32 321, ; 559
	i32 136, ; 560
	i32 149, ; 561
	i32 232, ; 562
	i32 154, ; 563
	i32 129, ; 564
	i32 19, ; 565
	i32 64, ; 566
	i32 146, ; 567
	i32 46, ; 568
	i32 329, ; 569
	i32 218, ; 570
	i32 78, ; 571
	i32 208, ; 572
	i32 60, ; 573
	i32 105, ; 574
	i32 267, ; 575
	i32 222, ; 576
	i32 48, ; 577
	i32 253, ; 578
	i32 326, ; 579
	i32 264, ; 580
	i32 14, ; 581
	i32 178, ; 582
	i32 67, ; 583
	i32 170, ; 584
	i32 332, ; 585
	i32 228, ; 586
	i32 232, ; 587
	i32 331, ; 588
	i32 186, ; 589
	i32 77, ; 590
	i32 237, ; 591
	i32 107, ; 592
	i32 221, ; 593
	i32 263, ; 594
	i32 213, ; 595
	i32 66, ; 596
	i32 62, ; 597
	i32 211, ; 598
	i32 159, ; 599
	i32 203, ; 600
	i32 230, ; 601
	i32 10, ; 602
	i32 191, ; 603
	i32 11, ; 604
	i32 77, ; 605
	i32 125, ; 606
	i32 82, ; 607
	i32 180, ; 608
	i32 65, ; 609
	i32 106, ; 610
	i32 64, ; 611
	i32 127, ; 612
	i32 121, ; 613
	i32 199, ; 614
	i32 76, ; 615
	i32 278, ; 616
	i32 268, ; 617
	i32 330, ; 618
	i32 8, ; 619
	i32 236, ; 620
	i32 2, ; 621
	i32 210, ; 622
	i32 43, ; 623
	i32 281, ; 624
	i32 155, ; 625
	i32 127, ; 626
	i32 266, ; 627
	i32 23, ; 628
	i32 132, ; 629
	i32 224, ; 630
	i32 255, ; 631
	i32 210, ; 632
	i32 325, ; 633
	i32 307, ; 634
	i32 28, ; 635
	i32 223, ; 636
	i32 61, ; 637
	i32 193, ; 638
	i32 89, ; 639
	i32 86, ; 640
	i32 147, ; 641
	i32 195, ; 642
	i32 35, ; 643
	i32 85, ; 644
	i32 244, ; 645
	i32 176, ; 646
	i32 320, ; 647
	i32 315, ; 648
	i32 179, ; 649
	i32 49, ; 650
	i32 6, ; 651
	i32 89, ; 652
	i32 327, ; 653
	i32 21, ; 654
	i32 161, ; 655
	i32 95, ; 656
	i32 49, ; 657
	i32 112, ; 658
	i32 260, ; 659
	i32 333, ; 660
	i32 129, ; 661
	i32 75, ; 662
	i32 211, ; 663
	i32 237, ; 664
	i32 259, ; 665
	i32 7, ; 666
	i32 212, ; 667
	i32 192, ; 668
	i32 109, ; 669
	i32 260, ; 670
	i32 246 ; 671
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.4xx @ a8cd27e430e55df3e3c1e3a43d35c11d9512a2db"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"NumRegisterParameters", i32 0}
