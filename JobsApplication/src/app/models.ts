export interface JobApplication {
    id: number;
    name: string;
    email: string;
    dateOfBirth: string;
    cvBlob: string;
}

export interface JobApplicationSave {
    name: string;
    email: string;
    dateOfBirth: string;
}