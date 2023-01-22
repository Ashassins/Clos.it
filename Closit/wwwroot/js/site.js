// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
import { dotnet } from './dotnet.js'

const is_browser = typeof window != "undefined";
if (!is_browser) throw new Error(`Expected to be running in a browser`);
const { setModuleImports, getAssemblyExports, getConfig } = 
    await dotnet.create();

setModuleImports("main.js", {
    window: {
    location: {
        href: () => globalThis.window.location.href
    }
    }
});

const config = getConfig();
const exports = await getAssemblyExports(config.mainAssemblyName);
const text = exports.MyClass.Greeting();
console.log(text);

document.getElementById("out").innerHTML = text;
await dotnet.run();