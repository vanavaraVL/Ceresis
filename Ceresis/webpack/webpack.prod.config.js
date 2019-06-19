var path = require('path');
var merge = require('webpack-merge');
var uglifyJsPlugin = require('uglifyjs-webpack-plugin');

module.exports = function (env) {
    return merge(require('./webpack.base.config.js')(env), {
        entry: {
            'settings': path.resolve(__dirname, '../App/Settings/settings.prod.ts'),
        },
        plugins: [
            new uglifyJsPlugin({
                test: /\.js($|\?)/i
            })
        ]
    })
};