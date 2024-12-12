interface ISUBROUTE{
    ROUTE: string;
    FULL: string;
}
export const APP_MAIN_ROUTES = {
    //article
    ARTICLE: 'article',
    USER: 'user'
} as const;

export const APP_SUB_ROUTES = {
    WRITE_ARTICLE: {
        ROUTE: 'write',
        get FULL() { return APP_MAIN_ROUTES.ARTICLE + '/' + this.ROUTE; }
    },
    VIEW_ARTICLE: {
        ROUTE: 'view',
        get FULL() { return APP_MAIN_ROUTES.ARTICLE + '/' + this.ROUTE; }
    }
} as const;