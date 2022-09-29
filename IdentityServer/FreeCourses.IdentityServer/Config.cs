// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace FreeCourses.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("resource_catalog"){Scopes={"catalog_fullpermission"}},
                new ApiResource("resource_photo_stock"){Scopes={"photo_stock_fullpermission"}},
                new ApiResource("resource_basket"){Scopes={"basket_fullpermission"}},
                new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
            };
        public static IEnumerable<IdentityResource> IdentityResources =>
                new IdentityResource[]
                {
                    new IdentityResources.Email(), //claimler
                    new IdentityResources.OpenId(), //claimler
                    new IdentityResources.Profile(), //claimler
                    new IdentityResource(){Name="roles", DisplayName = "Roles", Description = "Kullanıcı Rolleri", UserClaims = new []{"role"} }
                };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("catalog_fullpermission", "Catalog API için full erişim"),
                new ApiScope("photo_stock_fullpermission", "Photo Stock API için full erişim"),
                new ApiScope("basket_fullpermission", "Basket API için full erişim"),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientName = "Asp.Net Core MVC",
                    ClientId = "WebMvcClient",
                    ClientSecrets = {new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials, //Üyelik gerektirmeyen izinler için tanımlandı 
                    AllowedScopes = { "catalog_fullpermission", "photo_stock_fullpermission", IdentityServerConstants.LocalApi.ScopeName }
                },
                new Client
                {
                    ClientName = "Asp.Net Core MVC",
                    ClientId = "WebMvcClientForUser",
                    AllowOfflineAccess = true,
                    ClientSecrets = {new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword, //üyelik gerektiren izinler için tanımlandı 
                    AllowedScopes = {
                        "basket_fullpermission",
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId, //mutlaka olmalı.
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess, //refresh token üreteceğimizden dolayı ekledik. offline access sayesinde kullanıcı refresh token yollayıp yeni token alabiliyor.token expire oldukça sürekli email password girmek zorunda kalmasın diye
                        "roles",
                        IdentityServerConstants.LocalApi.ScopeName
                    }, //hangi izinler veriliyor.
                    AccessTokenLifetime= 1*60*60, // Token ömrü 1 saat
                    RefreshTokenExpiration = TokenExpiration.Absolute, //refresh token süresini uzatmaya izin vermiyor.
                    AbsoluteRefreshTokenLifetime = (int)(DateTime.Now.AddDays(60)- DateTime.Now).TotalSeconds, //refresh token ömrü 60 gün
                    RefreshTokenUsage = TokenUsage.ReUse //refresh token tekrar kullanılabilsin.
                },
            };
    }
}