import { userEducation } from "./userEducation";
import { userWorkExperience } from "./userWorkExperience";

export interface user{
    firstName:string;
    lastName:string;
    email:string;
    phoneNumber:string;
    dob:Date;
    gender:string;

    workExperiences:userWorkExperience[];
    educations: userEducation[];
}