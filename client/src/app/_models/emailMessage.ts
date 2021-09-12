export interface EmailMessage {
    from?: string;
    to?: string;
    cc?: string;
    subject?: string;
    importance?: string;
    content?:string
  } 