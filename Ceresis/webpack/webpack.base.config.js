var path = require("path");
var webpack = require("webpack");
var ExtractTextPlugin = require("extract-text-webpack-plugin");
const CopyPlugin = require('copy-webpack-plugin');

module.exports = function (env) {
    console.log(env);

    var rootDir = path.resolve(__dirname, '../');

    const coreApp = {
        entry: {
            'app_main': path.resolve(rootDir, "./App/main.module.ts"),
            'polyfills': path.resolve(rootDir, "./App/polyfills.ts"),
            'vendor': path.resolve(rootDir, "./App/vendor.ts"),
            'settings': path.resolve(rootDir, "./App/Settings/settings.ts"),
            './Scripts/home.component.load': path.resolve(rootDir, "./Scripts/home.component.load.js"),
        },
        output: {
            path: path.resolve(rootDir, "wwwroot"),
            publicPath: "/",
            filename: "[name].js"
        },
        resolve: {
            extensions: [".ts", ".js"]
        },
        module: {
            rules: [
                {
                    test: /\.ts$/,
                    use: [
                        {
                            loader: "awesome-typescript-loader",
                            options: { configFileName: path.resolve(rootDir, "tsconfig.json") }
                        },
                        "angular2-template-loader"
                    ]
                }, {
                    test: /\.html$/,
                    loader: "html-loader"
                }, {
                    test: /\.(otf|woff|woff2|ttf|eot|ico)$/,
                    loader: "file-loader?name=fonts/[name].[ext]"
                }, {
                    test: /\.(png|jpe?g|gif|svg)$/,
                    loader: "file-loader?name=images/[name].[ext]"
                },
                {
                    test: /\.scss$/,
                    include: [/App/,
                        path.resolve(rootDir, 'app/about'),
                        path.resolve(rootDir, 'app/appheader/'),
                        path.resolve(rootDir, 'app/admin/login'),
                        path.resolve(rootDir, 'app/admin/General'),
                        path.resolve(rootDir, 'app/admin/EditCatalog'),
                        path.resolve(rootDir, 'app/admin/Window/Add'),
                        path.resolve(rootDir, 'app/admin/Window/List'),
                        path.resolve(rootDir, 'app/admin/Window/Edit'),
                        path.resolve(rootDir, 'app/admin/SplitSystem/Add'),
                        path.resolve(rootDir, 'app/admin/SplitSystem/List'),
                        path.resolve(rootDir, 'app/admin/SplitSystem/Edit'),
                        path.resolve(rootDir, 'app/admin/Worksample/Add'),
                        path.resolve(rootDir, 'app/admin/Worksample/List'),
                        path.resolve(rootDir, 'app/admin/LogoTypes/Add'),
                        path.resolve(rootDir, 'app/admin/LogoTypes/List'),
                        path.resolve(rootDir, 'app/feedback'),
                        path.resolve(rootDir, 'app/portfolio'),
                        path.resolve(rootDir, 'app/production/split'),
                        path.resolve(rootDir, 'app/production/household'),
                    ],
                    loaders: ["raw-loader", "sass-loader"]
                },
                {
                    test: /\.scss$/,
                    include: [/Styles/],
                    use: ExtractTextPlugin.extract({
                        fallback: "style-loader",
                        use: ["css-loader", "sass-loader"]
                    })
                }
            ]
        },
        watch: !!env.watch,
        watchOptions: {
            ignored: /node_modules/
        },
        devtool: false,
        plugins: [
            new webpack.ContextReplacementPlugin(
                /angular(\\|\/)core/,
                path.resolve(rootDir, "src"),
                {}
            ),
            new ExtractTextPlugin("[name].css"),
            new CopyPlugin([
                { from: path.resolve(rootDir, "./images/favicon.ico") },
                { from: path.resolve(rootDir, "./images/favicon-16x16.png") },
                { from: path.resolve(rootDir, "./images/favicon-32x32.png") },
                { from: path.resolve(rootDir, "./images/favicon-152x152.png") },

                { from: path.resolve(rootDir, "./images/logoPath.png"), to: 'images' },
                { from: path.resolve(rootDir, "./images/cartItemPath.jpg"), to: 'images' },
                { from: path.resolve(rootDir, "./images/logo_2.png"), to: 'images' }
            ])
        ]
    };

    return coreApp;
};