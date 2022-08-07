# CCred.Sauce

Pardon the pun.

## Unambitious and straightforward hash library for .NET


``` csharp
var password = "longpassword";
var salt = CCred.Sauce.GenerateSalt(length: 8);

var hashedPassword = CCred.Sauce.GetHash(password, salt);
bool isMatch = CCred.Sauce.Verify(password, salt, hashedPassword);
```

By default the hash is compute using SHA384, but you can specify the `HashAlgorithm` from `System.Security.Cryptography` namespace.

``` csharp
var md1 = CCred.Sauce.GetHash<MD1>(password, salt);
var md5 = CCred.Sauce.GetHash<MD5>(password, salt);
var sha256 = CCred.Sauce.GetHash<SHA256>(password, salt);
var sha384 = CCred.Sauce.GetHash<SHA384>(password, salt);
var sha512 = CCred.Sauce.GetHash<SHA512>(password, salt);
```

You can manually salt a password.

``` csharp
var seasoning = CCred.Sauce.Seasoning(password, salt);

// PASSWORD     : "longpassword"
// SALT         : 1br1s128
// SEASONING    : l1obnrg1psa1s2s8w1obrrd
```

You can also generate random string.

``` csharp
var gibberish = CCred.Sauce.GenerateGibberish(32);

//OUTPUT
// 86d5lT09T330ZSO4m1B3840t8SCR0ge3
// 23U8o0ZQN0U6683v0y4p5C68G871k0s8
// i8P5E0I1dzau67yt0c0k45pBFI56Ws56
// W5U1vI9iZTP29o83CE42d612y37oUl99
// d2J23133548W4h4YC6tU2V71P79MS05v
```

With additional user-defined special or any characters really.
``` csharp
var gibberish = CCred.Sauce.GenerateGibberish(32, "!@#$%^&*-=_+.?");

// OUTPUT:
// NL38JC5h@.=9EyZg71?59^9mT$_4In2_
// 434#+^1Qf^r@G&*95Cw76J89a92L0%0#
// 48M342.*7?L7&5i?131.pvzs=B+oa43a
// s78=P=12^4&1083Eb503y@#37@132?#9
// 9HVc&^075=V52$9l&3.$N95J1&f80*O8
```
