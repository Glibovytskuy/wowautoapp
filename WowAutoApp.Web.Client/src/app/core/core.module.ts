import {NgModule, Optional, SkipSelf} from "@angular/core";
import {CommonModule} from "@angular/common";
import {HttpClientModule} from "@angular/common/http";
import { GlobalService } from "@app/services/general-services/global.service";
import { RoleGuard } from "@app/services/guards/role.guards";
import { NonAuthGuard } from "@app/services/guards/non-auth.guard";
import { AuthGuard } from "@app/services/guards/auth.guard";

//Services

@NgModule({
    imports: [
        CommonModule,
        HttpClientModule
    ],
    declarations: [],
    providers: [
        //services
        GlobalService,
        //guards
        RoleGuard,
        NonAuthGuard,
        AuthGuard
    ]
})

export class CoreModule {
    constructor(
        @Optional()
        @SkipSelf()
            parentModule: CoreModule
    ) {
        if (parentModule) {
            throw new Error('CoreModule is already loaded. Import only in AppModule');
        }
    }
}