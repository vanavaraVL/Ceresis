interface AOS {
    refresh(): void
    init(): void
}

declare const aos: AOS

declare module 'AOS' {
    export = aos
}