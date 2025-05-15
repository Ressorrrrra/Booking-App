module.exports = {
  pwa: {
    name: "Poolio",
    themeColor: "#205c94",
    msTileColor: "#205c94",
    appleMobileWebAppCapable: "yes",
    appleMobileWebAppStatusBarStyle: "#205c94",
    iconPaths: {
      favicon32: "./img/icons/favicon-32x32.png",
      favicon16: "./img/icons/favicon-16x16.png",
      favicon96: "./img/icons/favicon-96x96.png",
      appleTouchIcon: "./img/icons/apple-icon-152x152.png",
      msTitleImage: "./img/icons/ms-icon-144x144.png"
    },
    workboxPluginMode: "InjectManifest",
    workboxOptions: {
      swSrc: "src/service-worker.js"
    }
  }
};
