import { Injectable,Renderer2 } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EmbedJsService {
  constructor(private renderer: Renderer2 ) { }
  

  public loadScripts() {
    this.renderExternalScript('assets/js/main.js').onload = () => {
    }
    this.renderExternalScript('assets/js/map.js').onload = () => {
    }
    this.renderExternalScript('assets/js/plugin.js').onload = () => {
    }
  }
  public renderExternalScript(src: string): HTMLScriptElement {
    const script = document.createElement('script');
    script.type = 'text/javascript';
    script.src = src;
    script.async = true;
    script.defer = true;
    this.renderer.appendChild(document.body, script);
    return script;
  }
}
