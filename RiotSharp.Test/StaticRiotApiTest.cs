﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiotSharp.Caching;
using RiotSharp.Endpoints.Interfaces.Static;
using RiotSharp.Endpoints.StaticDataEndpoint;
using RiotSharp.Http;

namespace RiotSharp.Test
{
    [TestClass]
    public class StaticRiotApiTest : CommonTestBase
    {
        private readonly IStaticDataEndpoints _api;
        private static readonly RateLimitedRequester Requester = new RateLimitedRequester(ApiKey, new Dictionary<TimeSpan, int>
            {
                { new TimeSpan(1, 0, 0), 10 }
            });

        public StaticRiotApiTest()
        {
            var cache = new Cache();
            _api = StaticDataEndpoints.GetInstance(Requester.ApiKey, true);
        }


        #region Champions Tests

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetChampionAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var champ = _api.Champion.GetChampionAsync(StaticRiotApiTestBase.Region,
                    StaticRiotApiTestBase.StaticChampionId);

                Assert.AreEqual(StaticRiotApiTestBase.StaticChampionName, champ.Result.Name);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetChampionsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var champs = _api.Champion.GetChampionsAsync(StaticRiotApiTestBase.Region);

                Assert.IsTrue(champs.Result.Champions.Count > 0);
            });
        }

        #endregion

        #region Items Tests

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetItemsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var items = _api.Item.GetItemsAsync(StaticRiotApiTestBase.Region);

                Assert.IsTrue(items.Result.Items.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetItemAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var item = _api.Item.GetItemAsync(StaticRiotApiTestBase.Region,
                    StaticRiotApiTestBase.StaticItemId);

                Assert.AreEqual(StaticRiotApiTestBase.StaticItemName, item.Result.Name);
            });
        }
        #endregion

        #region Language Strings Tests

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetLanguageStringsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var strings = _api.Language.GetLanguageStringsAsync(StaticRiotApiTestBase.Region);

                Assert.IsTrue(strings.Result.Data.Count > 0);
            });
        }
        #endregion

        #region Languages Tests

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetLanguagesAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var langs = _api.Language.GetLanguagesAsync(StaticRiotApiTestBase.Region);

                Assert.IsTrue(langs.Result.Count > 0);
            });
        }
        #endregion

        #region Maps Tests

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetMapsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var maps = _api.Map.GetMapsAsync(StaticRiotApiTestBase.Region);

                Assert.IsTrue(maps.Result.Count > 0);
            });
        }
        #endregion

        #region Masteries

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetMasteriesAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var masteries = _api.Mastery.GetMasteriesAsync(StaticRiotApiTestBase.Region);

                Assert.IsTrue(masteries.Result.Masteries.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetMasteryAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var mastery = _api.Mastery.GetMasteryAsync(StaticRiotApiTestBase.Region,
                    StaticRiotApiTestBase.StaticMasteryId);

                Assert.AreEqual(StaticRiotApiTestBase.StaticMasteryName, mastery.Result.Name);
            });
        }
        #endregion

        #region Profile Icons Tests

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetProfileIconsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var profileIcons = _api.ProfileIcon.GetProfileIconsAsync(StaticRiotApiTestBase.Region).Result;

                Assert.IsTrue(profileIcons.ProfileIcons.Count > 0);
            });
        }
        #endregion

        #region Reforged Runes
        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetReforgedRunesAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var reforgedRunes = _api.ReforgedRune.GetReforgedRunesAsync(StaticRiotApiTestBase.Region).Result;

                Assert.IsTrue(reforgedRunes.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetReforgedRuneAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var reforgedRune = _api.ReforgedRune.GetReforgedRuneAsync(StaticRiotApiTestBase.Region,
                    StaticRiotApiTestBase.StaticReforgedRuneId).Result;

                Assert.AreEqual(StaticRiotApiTestBase.StaticReforgedRuneName, reforgedRune.Name);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetReforgedRunePathsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var reforgedRunePaths = _api.ReforgedRune.GetReforgedRunePathsAsync(StaticRiotApiTestBase.Region).Result;

                Assert.IsTrue(reforgedRunePaths.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetReforgedRunePathAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var reforgedRunePath = _api.ReforgedRune.GetReforgedRunePathAsync(StaticRiotApiTestBase.Region,
                    StaticRiotApiTestBase.StaticReforgedRunePathId).Result;

                Assert.AreEqual(StaticRiotApiTestBase.StaticReforgedRunePathName, reforgedRunePath.Name);
            });
        }
        #endregion

        #region Runes

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetRunesAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var runes = _api.Rune.GetRunesAsync(StaticRiotApiTestBase.Region).Result;

                Assert.IsTrue(runes.Runes.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetRuneAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var rune = _api.Rune.GetRuneAsync(StaticRiotApiTestBase.Region,
                    StaticRiotApiTestBase.StaticRuneId).Result;

                Assert.AreEqual(StaticRiotApiTestBase.StaticRuneName, rune.Name);
            });
        }
        #endregion

        #region Summoner Spells Tests

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetSummonerSpellsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var spells = _api.SummonerSpell.GetSummonerSpellsAsync(StaticRiotApiTestBase.Region);

                Assert.IsTrue(spells.Result.SummonerSpells.Count > 0);
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetSummonerSpellAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var spell = _api.SummonerSpell.GetSummonerSpellAsync(StaticRiotApiTestBase.Region,
                    (int)StaticRiotApiTestBase.StaticSummonerSpell);

                Assert.AreEqual(StaticRiotApiTestBase.StaticSummonerSpellName, spell.Result.Name);
            });
        }
        #endregion

        #region Versions Tests

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetVersionsAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var versions = _api.Version.GetVersionsAsync(StaticRiotApiTestBase.Region);

                Assert.IsTrue(versions.Result.Count() > 0);
            });
        }
        #endregion

        #region Realms Tests

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetRealmAsync_Test()
        {
            EnsureCredibility(() =>
            {
                var realm = _api.Realm.GetRealmAsync(StaticRiotApiTestBase.Region);

                Assert.IsNotNull(realm.Result);
            });
        }
        #endregion

        #region TarballLinks Tests

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetTarballLinksAsyncNoVersion_Test()
        {
            EnsureCredibility(() =>
            {
                var tarballLink = _api.TarballLink.GetTarballLinksAsync(StaticRiotApiTestBase.Region);

                Assert.IsTrue(tarballLink.Result.StartsWith(StaticRiotApiTestBase.StaticTarballLinkBaseUrl));
            });
        }

        [TestMethod]
        [TestCategory("StaticRiotApi"), TestCategory("Async")]
        public void GetTarballLinksAsyncVersion_Test()
        {
            EnsureCredibility(() =>
            {
                var tarballLink = _api.TarballLink.GetTarballLinksAsync(StaticRiotApiTestBase.Region,
                StaticRiotApiTestBase.StaticTarballLinkVersion);
                
                Assert.AreEqual(StaticRiotApiTestBase.StaticTarballLinkVersionUrl, tarballLink.Result);
            });
        }
        #endregion
    }
}
