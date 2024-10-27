import { education } from "./feature.education.model";
import { workExperience } from "./feature.workExperience.model";

export interface user{
    firstName:string;
    lastName:string;
    email:string;
    phoneNumber:string;
    dob:Date;
    gender:string;

    workExperiences:workExperience[];
    educations: education[];
}