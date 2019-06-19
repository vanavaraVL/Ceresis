module.exports = function (env) {
    console.log(`Start build ${env.env}`);

    switch (env.env) {
        case 'prod':
            return require('./webpack/webpack.prod.config')(env);
        default:
            return require('./webpack/webpack.dev.config')(env);
    }
};