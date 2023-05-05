import Reveal from "reveal.js"
import Highlight from "reveal.js/plugin/highlight/highlight.esm"
import Markdown from "reveal.js/plugin/markdown/markdown.esm"

const deck = new Reveal({
	disableLayout: true,
	plugins: [Markdown, Highlight],
})

deck.initialize()
