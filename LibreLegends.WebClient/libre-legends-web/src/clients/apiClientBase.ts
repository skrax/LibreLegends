export abstract class ApiClientBase {
    protected readonly baseUrl: string;

    protected constructor(baseUrl: string) {
        this.baseUrl = baseUrl;
    }

    protected async get<T>(url: string) {
        const response = await fetch(`${this.baseUrl}${url}`, {
            method: 'GET',
        })

        if (!response.ok) {
            throw {
                response,
                message: response.statusText
            };
        }

        return await response.json() as T;
    }

    protected async post<T>(url: string, data: any) {
        const response = await fetch(`${this.baseUrl}${url}`, {
            method: 'POST',
            body: JSON.stringify(data),
            headers: {
                'Content-Type': 'application/json'
            }
        })

        if (!response.ok) {
            throw {
                response,
                message: response.statusText
            }
        }

        return await response.json() as T;
    }

    protected async put<T>(url: string, data: any) {
        const response = await fetch(`${this.baseUrl}${url}`, {
            method: 'PUT',
            body: JSON.stringify(data),
            headers: {
                'Content-Type': 'application/json'
            }
        })

        if (!response.ok) {
            throw {
                response,
                message: response.statusText
            }
        }

        return await response.json() as T;
    }

    protected async patch<T>(url: string, data: any) {
        const response = await fetch(`${this.baseUrl}${url}`, {
            method: 'PATCH',
            body: JSON.stringify(data),
            headers: {
                'Content-Type': 'application/json'
            }
        })

        if (!response.ok) {
            throw {
                response,
                message: response.statusText
            }
        }

        return await response.json() as T;
    }

    protected async delete(url: string) {
        const response = await fetch(`${this.baseUrl}${url}`, {
            method: 'DELETE',
        })

        if (!response.ok) {
            throw {
                response,
                message: response.statusText
            }
        }
    }
}