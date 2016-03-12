requirejs.config({
    paths: {
        'jQuery': '../Scripts',
        'text': '../Scripts/text',
        'durandal': '../Scripts/durandal',
        'plugins': '../Scripts/durandal/plugins',
        'transitions': '../Scripts/durandal/transitions',
        'service': abp.appPath + 'Abp/Framework/scripts/libs/requirejs/plugins/service'
    }
});

define('jquery', function () { return jQuery; });
define('knockout', function () { return ko; });
define('moment', function () { return moment; });
define('underscore', function () { return _; });

define(['durandal/system', 'durandal/app', 'durandal/viewLocator', 'durandal/viewEngine', 'durandal/activator', 'knockout'], function (system, app, viewLocator, viewEngine, activator, ko) {
    system.debug(true); //TODO: remove in production code

    return {

    };
});