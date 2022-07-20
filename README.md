# CCred.Sauce

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

You can manually salt a password

``` csharp
var seasoning = CCred.Sauce.Seasoning(password, salt);

// PASSWORD     : "longpassword"
// SALT         : 1br1s128
// SEASONING    : l1obnrg1psa1s2s8w1obrrd
```