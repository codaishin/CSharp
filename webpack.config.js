const path = require('path');

module.exports = {
	entry: './Folien/presentation.js',
	output: {
		path: path.resolve(__dirname, 'Folien'),
		filename: 'presentation.bundle.js',
	},
};
