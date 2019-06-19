var path = require('path');
var merge = require('webpack-merge');

module.exports = function (env) {
    return merge(require('./webpack.base.config.js')(env), {
        entry: {
            'settings': path.resolve(__dirname, '../App/Settings/settings.dev.ts'),
        },
        module: {
            rules: [{
                test: /\.ts$/,
                enforce: 'pre',
                use: [{
                    loader: 'tslint-loader'
                }]
            }]
        }
    });
};