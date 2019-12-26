import {Pipe, PipeTransform} from "@angular/core";

@Pipe({name: 'stringSplitter'})
export class StringSplitterPipe implements PipeTransform {
    transform(value, args?:string[]) : any {
        if(value){
            var str = value.split(/(?=[A-Z])/).join(" ");
            return str.charAt(0).toUpperCase() + str.slice(1);
        }
    }
}