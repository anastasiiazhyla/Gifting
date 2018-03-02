import { Component, OnInit } from "@angular/core";
import { UserProfile } from '../models/account';

@Component({
	selector: "app-header",
	templateUrl: "./header.component.html",
	styleUrls: ["./header.component.css"]
})
export class HeaderComponent implements OnInit {

	constructor(private authProfile: UserProfile) {}

	ngOnInit() {
	}

	logOut() {
		this.authProfile.resetProfile();
	}
}
