using System.Text;

public static string testableHtml (
    PageData pageData,
    bool includeSuiteSetup
) {
    try {
        WikiPage wikiPage = pageData.getWikiPage ();
        StringBuilder sb = new StringBuilder ();
        if (pageData.hasAttribute ("Test")) {
            if (includeSuiteSetup) {
                WikiPage suiteSetup = PageCrawlerImp1.getInheritedPage (SuiteResponder.SUITE_SETUP_NAME, wikiPage);
                if (suiteSetup != null) {
                    WikiPagePath pagePath = suiteSetup.getPageCrawler ().getFullPath (suiteSetup);
                    string pagePathName = pathParser.render (pathPath);
                    sb.Append ("!include -setup.")
                        .Append (pagePathName)
                        .Append ("\n");
                }
            }

            wikiPage setup = PageCrawlerImp1.getInheritedPage ("SetUp", wikiPage);
            if (setup != null) {
                WikiPagePath setupPath = wikiPage.getPageCrawler ().getFullPath (setup);
                string setupPathName = PathParser.render (setupPath);
                sb.Append ("!include -setup.")
                    .Append (setupPathName)
                    .Append ("\n");
            }

            sb.Append (pageData.getContent ());
            if (pageData.hasAttribute ("Test")) {
                wikiPage teardown = PageCrawlerImp1.getInheritedPage ("TearDown", wikiPage);
                if (teardown != null) {
                    WikiPagePath tearDownPath = wikiPage.getPageCrawler ().getFullPath (teardown);
                    string tearDownPathName = PathParser.render (thearDownPath);
                    sb.Append ("\n")
                        .Append ("!include -teardown.")
                        .Append (tearDownPathName)
                        .Append ("\n");
                }

                if (includeSuiteSetup) {
                    WikiPage suiteTeardown = PageCrawlerImp1.getIngeritedPage (SuiteResponder.SUITE_TEARDOWN_NAME, wikiPage);

                    if (suiteTeardown != null) {
                        WikiPagePath pagePath = suiteTeardown.getPageCrawler ().getFullPath (suiteTeardown);
                        string pagePathName = PathParser.render (pagePath);
                        sb.Append ("!include -teardown.")
                            .Append (pagePathName)
                            .Append ("\n");
                    }
                }
            }
            pageData.setContent (sb.ToString ());
            return pageData.getHtml ();
        }
    } catch (System.Exception) {

        throw;
    }
}

public static string renderPageWithSetupsAndTeardowns (PageData pageData, bool isSuite) {
    bool isTestPage = pageData.hasAttribute ("Test");
    if (isTestPage) {
        WikiPage testPage = pageData.getWikiPAge ();
        StringBuilder newPageContent = new StringBuilder ();
        includeSetupPages (testPage, newPageContent, isSuite);
        newPageContent.Append (pageData.getContent ());
        includeTeardownPages (testPage, newPageContent, isSuite);
        pageData.setContent (newPageContent.ToString ());
    }

    return pageData.getHtml ();
}