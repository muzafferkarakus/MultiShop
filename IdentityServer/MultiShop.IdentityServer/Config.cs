﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog") { Scopes={"CatalogFullPermission","CatalogReadPermission"}},
            new ApiResource("ResourceDiscount"){ Scopes={"DiscountFullPermission","DiscountReadPermission"}},
            new ApiResource("ResourceOrder"){ Scopes={"OrderFullPermission","OrderReadPermission"}},
            new ApiResource("ResourceCargo"){ Scopes={"CargoFullPermission"}},
            new ApiResource("ResourceBasket"){ Scopes={"BasketFullPermission"}},
            new ApiResource("ResourcComment"){ Scopes={"CommentFullPermission"}},
            new ApiResource("ResourcPayment"){ Scopes={"PaymentFullPermission"}},
            new ApiResource("ResourcImages"){ Scopes={"ImagesFullPermission"}},
            new ApiResource("ResourceMessage"){ Scopes={"MessageFullPermission"}},
            new ApiResource("ResourceOcelot"){ Scopes={"OcelotFullPermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog transactions"),
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("DiscountReadPermission","Reading authority for discount transactions"),
            new ApiScope("OrderFullPermission","Full authority for order operations"),
            new ApiScope("OrderReadPermission","Reading authority for order transactions"),
            new ApiScope("CargoFullPermission","Full authority for cargo transactions"),
            new ApiScope("BasketFullPermission","Full authority for basket transactions"),
            new ApiScope("CommentFullPermission","Full authority for comment transactions"),
            new ApiScope("PaymentFullPermission","Full authority for payment transactions"),
            new ApiScope("ImagesFullPermission","Full authority for images transactions"),
            new ApiScope("MessageFullPermission","Full authority for images transactions"),
            new ApiScope("OcelotFullPermission","Full authority for ocelot transactions"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId="MultiShopVisitorId",
                ClientName="Multi Shop Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission","CatalogFullPermission", "OcelotFullPermission", "ImagesFullPermission", "CommentFullPermission", IdentityServerConstants.LocalApi.ScopeName },
                AllowAccessTokensViaBrowser=true
            },

            //Manager
            new Client
            {
                ClientId="MultiShopManagerId",
                ClientName="Multi Shop Manager User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission", "CargoFullPermission", "OcelotFullPermission", "CommentFullPermission", "PaymentFullPermission", "ImagesFullPermission","BasketFullPermission","DiscountFullPermission","OrderFullPermission","MessageFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                }
            },

            //Admin
            new Client
            {
                ClientId="MultiShopAdminId",
                ClientName="Multi Shop Admin User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("multishopsecret".Sha256())},
                AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderFullPermission", "CargoFullPermission", "BasketFullPermission","OcelotFullPermission","CommentFullPermission","PaymentFullPermission","ImagesFullPermission","MessageFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime=600
            }
        };
    }
}